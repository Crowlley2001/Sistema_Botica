USE [$(BaseDatos)];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @IdUsuario INT;
DECLARE @IdProducto CHAR(20);
DECLARE @PrecioCompra DECIMAL(18,2);
DECLARE @PrecioVenta DECIMAL(18,2);
DECLARE @StockAntes DECIMAL(18,3);
DECLARE @NumeroAntes VARCHAR(20);
DECLARE @IdCompra VARCHAR(11);
DECLARE @FechaPrueba DATETIME = GETDATE();
DECLARE @FacturaPrueba VARCHAR(20) =
    'TEST-' + RIGHT(REPLACE(CONVERT(VARCHAR(36), NEWID()), '-', ''), 14);
DECLARE @Detalles dbo.CompraDetalleType;

SELECT TOP (1) @IdUsuario = Id_Usu
FROM dbo.Usuarios
WHERE Estado_Usu = 'Activo'
ORDER BY Id_Usu;

SELECT TOP (1)
    @IdProducto = p.Id_Pro,
    @PrecioCompra = CONVERT(DECIMAL(18,2), p.Pre_CompraS),
    @PrecioVenta = CONVERT(DECIMAL(18,2), p.Pre_venta),
    @StockAntes = CONVERT(DECIMAL(18,3), p.Stock_Actual)
FROM dbo.Productos p
INNER JOIN dbo.KardexProducto k
    ON k.Id_Pro = p.Id_Pro
   AND k.EstadoKrdx = 'Activo'
WHERE p.Estado_Pro = 'Activo'
ORDER BY p.Id_Pro;

SELECT @NumeroAntes = RTRIM(Numero)
FROM dbo.Tipo_Doc
WHERE Id_Tipo = 9 AND Estado_TiDoc = 'Activo';

IF @IdUsuario IS NULL OR @IdProducto IS NULL OR @NumeroAntes IS NULL
    THROW 53001, 'No existen datos mínimos para ejecutar la prueba.', 1;

SET @PrecioCompra = ISNULL(@PrecioCompra, 1);
SET @PrecioVenta = ISNULL(@PrecioVenta, @PrecioCompra);

INSERT INTO @Detalles
(
    Id_Pro, PrecioCompraSoles, Cantidad, ImporteSoles, PrecioVentaSoles
)
VALUES
(
    @IdProducto, @PrecioCompra, 1, @PrecioCompra, @PrecioVenta
);

BEGIN TRANSACTION;

EXEC dbo.Sp_Registrar_Compra_Completa
    @NroFacturaFisica = @FacturaPrueba,
    @SubTotalSoles = @PrecioCompra,
    @FechaIngreso = @FechaPrueba,
    @TotalSoles = @PrecioCompra,
    @IdUsuario = @IdUsuario,
    @ModalidadPago = 'Contado',
    @TiempoEspera = 0,
    @FechaVencimiento = '2099-12-31',
    @DatosAdicionales = 'Prueba automática con rollback',
    @TipoDocumentoCompra = 'FACTURA',
    @TipoRegistro = 'Compra',
    @LugarSalida = 'PRUEBA',
    @TipoProceso = 'Entrada',
    @CodigoMoneda = 'PEN',
    @TipoCambio = 1,
    @TotalMoneda = @PrecioCompra,
    @Detalles = @Detalles,
    @IdCompraGenerado = @IdCompra OUTPUT;

IF NOT EXISTS
    (SELECT 1 FROM dbo.DocumentoCompras WHERE Id_DocComp = @IdCompra)
    THROW 53002, 'No se creó el documento de compra.', 1;

IF NOT EXISTS
    (SELECT 1 FROM dbo.Detalle_DocumCompra WHERE Id_DocComp = @IdCompra)
    THROW 53003, 'No se creó el detalle de compra.', 1;

IF NOT EXISTS
    (SELECT 1 FROM dbo.Detalle_Kardex WHERE Doc_Soporte = @FacturaPrueba)
    THROW 53004, 'No se creó el movimiento de Kardex.', 1;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Productos
    WHERE Id_Pro = @IdProducto
      AND CONVERT(DECIMAL(18,3), Stock_Actual) = @StockAntes + 1
)
    THROW 53005, 'El stock no se incrementó correctamente.', 1;

SELECT
    @IdCompra AS CompraGenerada,
    @FacturaPrueba AS ComprobantePrueba,
    'PRUEBA CORRECTA: se revertirán todos los cambios' AS Resultado;

ROLLBACK TRANSACTION;

IF EXISTS (SELECT 1 FROM dbo.DocumentoCompras WHERE Id_DocComp = @IdCompra)
    THROW 53006, 'El rollback no eliminó la compra de prueba.', 1;

IF EXISTS (SELECT 1 FROM dbo.Detalle_Kardex WHERE Doc_Soporte = @FacturaPrueba)
    THROW 53007, 'El rollback no eliminó el movimiento de Kardex.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Productos
    WHERE Id_Pro = @IdProducto
      AND CONVERT(DECIMAL(18,3), Stock_Actual) <> @StockAntes
)
    THROW 53008, 'El rollback no restauró el stock original.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Tipo_Doc
    WHERE Id_Tipo = 9
      AND RTRIM(Numero) <> @NumeroAntes
)
    THROW 53009, 'El rollback no restauró el correlativo.', 1;

SELECT 'ROLLBACK VERIFICADO: la base quedó sin datos de prueba' AS ResultadoFinal;
GO
