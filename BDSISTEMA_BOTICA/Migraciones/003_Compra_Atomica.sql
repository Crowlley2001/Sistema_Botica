USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF TYPE_ID(N'dbo.CompraDetalleType') IS NULL
BEGIN
    EXEC(N'
        CREATE TYPE dbo.CompraDetalleType AS TABLE
        (
            Id_Pro CHAR(20) NOT NULL,
            PrecioCompraSoles DECIMAL(18,2) NOT NULL,
            Cantidad DECIMAL(18,3) NOT NULL,
            ImporteSoles DECIMAL(18,2) NOT NULL,
            PrecioVentaSoles DECIMAL(18,2) NOT NULL
        );');
END;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Registrar_Compra_Completa
    @NroFacturaFisica CHAR(20),
    @SubTotalSoles DECIMAL(18,2),
    @FechaIngreso DATETIME,
    @TotalSoles DECIMAL(18,2),
    @IdUsuario INT,
    @ModalidadPago VARCHAR(50),
    @TiempoEspera INT,
    @FechaVencimiento DATE,
    @DatosAdicionales NVARCHAR(150),
    @TipoDocumentoCompra VARCHAR(12),
    @TipoRegistro VARCHAR(15),
    @LugarSalida VARCHAR(250),
    @TipoProceso VARCHAR(15),
    @CodigoMoneda CHAR(3),
    @TipoCambio DECIMAL(18,6),
    @TotalMoneda DECIMAL(18,2),
    @Detalles dbo.CompraDetalleType READONLY,
    @IdCompraGenerado VARCHAR(11) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @NroFacturaFisica = LTRIM(RTRIM(@NroFacturaFisica));

    IF LEN(@NroFacturaFisica) < 2
        THROW 52001, 'Debe indicar el comprobante físico del proveedor.', 1;

    IF @FechaVencimiento < CONVERT(DATE, @FechaIngreso)
        THROW 52002, 'La fecha de vencimiento no puede ser anterior a la compra.', 1;

    IF NOT EXISTS (SELECT 1 FROM @Detalles)
        THROW 52003, 'La compra debe contener al menos un producto.', 1;

    IF EXISTS
    (
        SELECT 1
        FROM @Detalles
        WHERE Cantidad <= 0
           OR PrecioCompraSoles < 0
           OR ImporteSoles < 0
           OR PrecioVentaSoles < 0
    )
        THROW 52004, 'El detalle contiene cantidades o importes inválidos.', 1;

    IF @CodigoMoneda NOT IN ('PEN', 'USD') OR @TipoCambio <= 0
        THROW 52005, 'La moneda o el tipo de cambio de la compra no es válido.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS
        (
            SELECT 1
            FROM dbo.DocumentoCompras WITH (UPDLOCK, HOLDLOCK)
            WHERE RTRIM(NroFac_Fisico) = RTRIM(@NroFacturaFisica)
              AND Estado_Ingre = 'Activo'
        )
            THROW 52006, 'El comprobante del proveedor ya fue registrado.', 1;

        SELECT @IdCompraGenerado =
            RTRIM(Serie) + '-' + RIGHT('000000' + RTRIM(Numero), 6)
        FROM dbo.Tipo_Doc WITH (UPDLOCK, HOLDLOCK)
        WHERE Id_Tipo = 9 AND Estado_TiDoc = 'Activo';

        IF @IdCompraGenerado IS NULL
            THROW 52007, 'No existe un correlativo activo para compras.', 1;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles d
            LEFT JOIN dbo.Productos p WITH (UPDLOCK, HOLDLOCK)
                ON p.Id_Pro = d.Id_Pro
            WHERE p.Id_Pro IS NULL OR p.Estado_Pro <> 'Activo'
        )
            THROW 52008, 'Uno o más productos no existen o están inactivos.', 1;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles d
            LEFT JOIN dbo.KardexProducto k WITH (UPDLOCK, HOLDLOCK)
                ON k.Id_Pro = d.Id_Pro AND k.EstadoKrdx = 'Activo'
            WHERE k.Id_krdx IS NULL
        )
            THROW 52009, 'Uno o más productos no tienen un Kardex activo.', 1;

        INSERT INTO dbo.DocumentoCompras
        (
            Id_DocComp, NroFac_Fisico, SubTotal_ingre, Fecha_Ingre,
            Total_Ingre, id_Usu, ModalidadPago, TiempoEspera,
            Fecha_Vencimiento, Estado_Ingre, Datos_Adicional,
            TipoDoc_Compra, Tiporegistro, LugarSalida, TipoProceso,
            CodigoMoneda, TipoCambio, TotalMoneda, TotalSoles
        )
        VALUES
        (
            @IdCompraGenerado, @NroFacturaFisica, @SubTotalSoles,
            @FechaIngreso, @TotalSoles, @IdUsuario, @ModalidadPago,
            @TiempoEspera, @FechaVencimiento, 'Activo', @DatosAdicionales,
            @TipoDocumentoCompra, @TipoRegistro, @LugarSalida, @TipoProceso,
            @CodigoMoneda, @TipoCambio, @TotalMoneda, @TotalSoles
        );

        INSERT INTO dbo.Detalle_DocumCompra
        (
            Id_DocComp, Id_Pro, PrecioUnit, Cantidad, Importe, preventa
        )
        SELECT
            @IdCompraGenerado, Id_Pro, PrecioCompraSoles,
            Cantidad, ImporteSoles, PrecioVentaSoles
        FROM @Detalles;

        ;WITH ProductosCompra AS
        (
            SELECT
                Id_Pro,
                SUM(Cantidad) AS Cantidad,
                MAX(PrecioCompraSoles) AS PrecioCompra,
                MAX(PrecioVentaSoles) AS PrecioVenta
            FROM @Detalles
            GROUP BY Id_Pro
        )
        UPDATE p
        SET p.Stock_Actual = p.Stock_Actual + c.Cantidad,
            p.Pre_CompraS = c.PrecioCompra,
            p.Pre_venta = c.PrecioVenta,
            p.UtilidadUnit = c.PrecioVenta - c.PrecioCompra,
            p.Valor_porCant = (p.Stock_Actual + c.Cantidad) * c.PrecioCompra
        FROM dbo.Productos p
        INNER JOIN ProductosCompra c ON c.Id_Pro = p.Id_Pro;

        ;WITH ProductosCompra AS
        (
            SELECT
                Id_Pro,
                SUM(Cantidad) AS Cantidad,
                MAX(PrecioCompraSoles) AS PrecioCompra
            FROM @Detalles
            GROUP BY Id_Pro
        )
        INSERT INTO dbo.Detalle_Kardex
        (
            Id_krdx, Item, Fecha_Krdx, Doc_Soporte, Det_Operacion,
            Cantidad_In, Precio_In, Total_In, Cantidad_Out, Precio_Out,
            Total_Out, Cantidad_Saldo, Promedio, Costo_Total_Saldo,
            Id_Usu, Tipo_operacion, Cant_Difncial, ImportDiferen
        )
        SELECT
            k.Id_krdx,
            ISNULL(ultimo.UltimoItem, 0) + 1,
            @FechaIngreso,
            @NroFacturaFisica,
            'Compra de mercadería',
            c.Cantidad,
            c.PrecioCompra,
            c.Cantidad * c.PrecioCompra,
            0, 0, 0,
            p.Stock_Actual,
            c.PrecioCompra,
            p.Stock_Actual * c.PrecioCompra,
            @IdUsuario,
            @TipoRegistro,
            '-',
            0
        FROM ProductosCompra c
        INNER JOIN dbo.Productos p ON p.Id_Pro = c.Id_Pro
        INNER JOIN dbo.KardexProducto k ON k.Id_Pro = c.Id_Pro
            AND k.EstadoKrdx = 'Activo'
        OUTER APPLY
        (
            SELECT MAX(dk.Item) AS UltimoItem
            FROM dbo.Detalle_Kardex dk WITH (UPDLOCK, HOLDLOCK)
            WHERE dk.Id_krdx = k.Id_krdx
        ) ultimo;

        UPDATE dbo.Tipo_Doc
        SET Numero = RIGHT('000000' + CONVERT(VARCHAR(6), CONVERT(INT, Numero) + 1), 6)
        WHERE Id_Tipo = 9;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
