USE [$(BaseDatos)];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @IdCliente CHAR(10);
DECLARE @IdUsuario INT;
DECLARE @IdProducto CHAR(20);
DECLARE @Precio DECIMAL(18,2);
DECLARE @Costo DECIMAL(18,2);
DECLARE @Total DECIMAL(18,2);
DECLARE @SubTotal DECIMAL(18,2);
DECLARE @Igv DECIMAL(18,2);
DECLARE @TotalGanancia DECIMAL(18,2);
DECLARE @IdPedido VARCHAR(11);
DECLARE @IdDocumento VARCHAR(11);
DECLARE @FechaPrueba DATETIME = GETDATE();
DECLARE @Detalles dbo.VentaDetalleType;

SELECT TOP (1) @IdCliente = Id_Cliente
FROM dbo.Cliente
WHERE Estado_Cli = 'Activo'
ORDER BY Id_Cliente;

SELECT TOP (1) @IdUsuario = Id_Usu
FROM dbo.Usuarios
WHERE Estado_Usu = 'Activo'
ORDER BY Id_Usu;

SELECT TOP (1)
    @IdProducto = p.Id_Pro,
    @Precio = CONVERT(DECIMAL(18,2), p.Pre_venta),
    @Costo = CONVERT(DECIMAL(18,2), p.Pre_CompraS)
FROM dbo.Productos p
INNER JOIN dbo.KardexProducto k
    ON k.Id_Pro = p.Id_Pro
   AND k.EstadoKrdx = 'Activo'
WHERE p.Estado_Pro = 'Activo'
  AND p.Stock_Actual >= 1
ORDER BY p.Id_Pro;

IF @IdCliente IS NULL OR @IdUsuario IS NULL OR @IdProducto IS NULL
    THROW 51001, 'No existen datos mínimos para ejecutar la prueba.', 1;

SET @Total = @Precio;
SET @SubTotal = ROUND(@Total / 1.18, 2);
SET @Igv = @Total - @SubTotal;
SET @TotalGanancia = @Precio - @Costo;

INSERT INTO @Detalles
(
    Id_Pro, Precio, Cantidad, Importe,
    Utilidad_Unit, TotalUtilidad, DescuentoDet
)
VALUES
(
    @IdProducto, @Precio, 1, @Precio,
    @Precio - @Costo, @Precio - @Costo, 0
);

BEGIN TRANSACTION;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Cierre_Caja
    WHERE Id_Usu = @IdUsuario
      AND Estado_cierre = 'Abierto'
      AND CONVERT(date, Fecha_Cierre) = CONVERT(date, GETDATE())
)
BEGIN
    INSERT INTO dbo.Cierre_Caja
    (
        Id_cierre, Fecha_Cierre, Apertura_Caja, Total_Ingreso,
        TotalEgreso, Id_Usu, TodoDeposito, Gananciadeldia,
        TotalEntregado, SaldoSiguiente, TotalFactura, TotalBoleta,
        TotalNotaVenta, TotalCreditoCobrado, TotalCreditoEmitido,
        Estado_cierre
    )
    VALUES
    (
        'TEST-CAJA1', GETDATE(), 0, 0,
        0, @IdUsuario, 0, 0,
        0, 0, 0, 0,
        0, 0, 0, 'Abierto'
    );
END;

EXEC dbo.Sp_Registrar_Venta_Completa
    @Id_Cliente = @IdCliente,
    @Id_TipoDocumento = 3,
    @FechaEmision = @FechaPrueba,
    @SubTotal = @SubTotal,
    @Igv = @Igv,
    @TotalSoles = @Total,
    @TipoPago = 'Efectivo',
    @NroOperacion = '',
    @Id_Usuario = @IdUsuario,
    @TotalGanancia = @TotalGanancia,
    @TotalDescuento = 0,
    @CodigoMoneda = 'PEN',
    @TipoCambio = 1,
    @ImporteMoneda = @Total,
    @Detalles = @Detalles,
    @Id_PedidoGenerado = @IdPedido OUTPUT,
    @Id_DocumentoGenerado = @IdDocumento OUTPUT;

IF NOT EXISTS (SELECT 1 FROM dbo.Pedido WHERE id_Ped = @IdPedido)
    THROW 51002, 'No se creó el pedido dentro de la transacción.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Detalle_Pedido WHERE id_Ped = @IdPedido)
    THROW 51003, 'No se creó el detalle dentro de la transacción.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Documento WHERE id_Doc = @IdDocumento)
    THROW 51004, 'No se creó el documento dentro de la transacción.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Caja WHERE Nro_Doc = @IdDocumento)
    THROW 51005, 'No se creó el movimiento de caja dentro de la transacción.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Detalle_Kardex WHERE Doc_Soporte = @IdDocumento)
    THROW 51006, 'No se creó el movimiento de Kardex dentro de la transacción.', 1;

SELECT
    @IdPedido AS PedidoGenerado,
    @IdDocumento AS DocumentoGenerado,
    'PRUEBA CORRECTA: se revertirán todos los cambios' AS Resultado;

ROLLBACK TRANSACTION;

IF EXISTS (SELECT 1 FROM dbo.Documento WHERE id_Doc = @IdDocumento)
    THROW 51007, 'La prueba no revirtió correctamente el documento.', 1;

SELECT 'ROLLBACK VERIFICADO: la base quedó sin datos de prueba' AS ResultadoFinal;
GO
