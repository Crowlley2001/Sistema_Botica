USE [$(BaseDatos)];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @IdDocumento CHAR(11);
DECLARE @IdPedido CHAR(11);
DECLARE @IdUsuario INT;
DECLARE @KardexAnulacionAntes INT;

DECLARE @StockAntes TABLE
(
    Id_Pro CHAR(20) PRIMARY KEY,
    Stock DECIMAL(18,3) NOT NULL,
    CantidadVendida DECIMAL(18,3) NOT NULL
);

SELECT TOP (1)
    @IdDocumento = d.id_Doc,
    @IdPedido = d.id_Ped,
    @IdUsuario = d.Id_Usu
FROM dbo.Documento d
WHERE d.Estado_Doc = 'Activo'
  AND EXISTS
  (
      SELECT 1
      FROM dbo.Detalle_Pedido dp
      INNER JOIN dbo.KardexProducto k
          ON k.Id_Pro = dp.Id_Pro
         AND k.EstadoKrdx = 'Activo'
      WHERE dp.id_Ped = d.id_Ped
  )
ORDER BY d.Fecha_Emi DESC;

IF @IdDocumento IS NULL
    THROW 55001, 'No existe una venta activa apta para ejecutar la prueba.', 1;

INSERT INTO @StockAntes (Id_Pro, Stock, CantidadVendida)
SELECT
    p.Id_Pro,
    CONVERT(DECIMAL(18,3), p.Stock_Actual),
    SUM(CONVERT(DECIMAL(18,3), dp.Cantidad))
FROM dbo.Detalle_Pedido dp
INNER JOIN dbo.Productos p ON p.Id_Pro = dp.Id_Pro
WHERE dp.id_Ped = @IdPedido
GROUP BY p.Id_Pro, p.Stock_Actual;

SELECT @KardexAnulacionAntes = COUNT(*)
FROM dbo.Detalle_Kardex
WHERE RTRIM(Doc_Soporte) = RTRIM(@IdDocumento)
  AND Tipo_operacion = 'Anulacion';

BEGIN TRANSACTION;

EXEC dbo.Sp_Anular_Venta_Completa
    @IdDocumento = @IdDocumento,
    @DevolverStock = 1,
    @IdUsuario = @IdUsuario;

IF EXISTS
(
    SELECT 1
    FROM dbo.Documento
    WHERE id_Doc = @IdDocumento
      AND Estado_Doc <> 'Anulado'
)
    THROW 55002, 'El documento no quedó anulado.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Pedido
    WHERE id_Ped = @IdPedido
      AND Estado_Ped <> 'Anulado'
)
    THROW 55003, 'El pedido no quedó anulado.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Caja
    WHERE RTRIM(Nro_Doc) = RTRIM(@IdDocumento)
      AND EstadoCaja <> 'Anulado'
)
    THROW 55004, 'El movimiento de caja no quedó anulado.', 1;

IF EXISTS
(
    SELECT 1
    FROM @StockAntes a
    INNER JOIN dbo.Productos p ON p.Id_Pro = a.Id_Pro
    WHERE CONVERT(DECIMAL(18,3), p.Stock_Actual)
        <> a.Stock + a.CantidadVendida
)
    THROW 55005, 'La devolución de stock no coincide con la venta.', 1;

IF
(
    SELECT COUNT(*)
    FROM dbo.Detalle_Kardex
    WHERE RTRIM(Doc_Soporte) = RTRIM(@IdDocumento)
      AND Tipo_operacion = 'Anulacion'
) <= @KardexAnulacionAntes
    THROW 55006, 'No se registró la devolución en Kardex.', 1;

SELECT
    RTRIM(@IdDocumento) AS DocumentoProbado,
    'PRUEBA CORRECTA: se revertirá la anulación' AS Resultado;

ROLLBACK TRANSACTION;

IF EXISTS
(
    SELECT 1
    FROM dbo.Documento
    WHERE id_Doc = @IdDocumento
      AND Estado_Doc <> 'Activo'
)
    THROW 55007, 'El rollback no restauró el estado del documento.', 1;

IF EXISTS
(
    SELECT 1
    FROM @StockAntes a
    INNER JOIN dbo.Productos p ON p.Id_Pro = a.Id_Pro
    WHERE CONVERT(DECIMAL(18,3), p.Stock_Actual) <> a.Stock
)
    THROW 55008, 'El rollback no restauró el stock original.', 1;

IF
(
    SELECT COUNT(*)
    FROM dbo.Detalle_Kardex
    WHERE RTRIM(Doc_Soporte) = RTRIM(@IdDocumento)
      AND Tipo_operacion = 'Anulacion'
) <> @KardexAnulacionAntes
    THROW 55009, 'El rollback dejó movimientos de Kardex.', 1;

SELECT 'ROLLBACK VERIFICADO: la base quedó sin cambios de prueba' AS ResultadoFinal;
GO
