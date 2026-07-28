USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF TYPE_ID(N'dbo.VentaDetalleType') IS NULL
BEGIN
    EXEC(N'
        CREATE TYPE dbo.VentaDetalleType AS TABLE
        (
            Id_Pro CHAR(20) NOT NULL,
            Precio DECIMAL(18,2) NOT NULL,
            Cantidad DECIMAL(18,3) NOT NULL,
            Importe DECIMAL(18,2) NOT NULL,
            Utilidad_Unit DECIMAL(18,2) NOT NULL,
            TotalUtilidad DECIMAL(18,2) NOT NULL,
            DescuentoDet DECIMAL(18,2) NOT NULL
        );');
END;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Registrar_Venta_Completa
    @Id_Cliente CHAR(10),
    @Id_TipoDocumento INT,
    @FechaEmision DATETIME,
    @SubTotal DECIMAL(18,2),
    @Igv DECIMAL(18,2),
    @TotalSoles DECIMAL(18,2),
    @TipoPago VARCHAR(50),
    @NroOperacion NCHAR(20),
    @Id_Usuario INT,
    @TotalGanancia DECIMAL(18,2),
    @TotalDescuento DECIMAL(18,2),
    @CodigoMoneda CHAR(3),
    @TipoCambio DECIMAL(18,6),
    @ImporteMoneda DECIMAL(18,2),
    @Detalles dbo.VentaDetalleType READONLY,
    @Id_PedidoGenerado VARCHAR(11) OUTPUT,
    @Id_DocumentoGenerado VARCHAR(11) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM @Detalles)
        THROW 50001, 'La venta debe contener al menos un producto.', 1;

    IF EXISTS
    (
        SELECT 1
        FROM @Detalles
        WHERE Cantidad <= 0 OR Precio < 0 OR Importe < 0
    )
        THROW 50002, 'El detalle contiene cantidades o importes inválidos.', 1;

    IF @CodigoMoneda NOT IN ('PEN', 'USD')
        THROW 50003, 'La moneda de la venta no es válida.', 1;

    IF @TipoCambio <= 0
        THROW 50004, 'El tipo de cambio debe ser mayor a cero.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @Id_PedidoGenerado = RTRIM(Serie) + '-' + RIGHT('000000' + RTRIM(Numero), 6)
        FROM dbo.Tipo_Doc WITH (UPDLOCK, HOLDLOCK)
        WHERE Id_Tipo = 4 AND Estado_TiDoc = 'Activo';

        SELECT @Id_DocumentoGenerado = RTRIM(Serie) + '-' + RIGHT('000000' + RTRIM(Numero), 6)
        FROM dbo.Tipo_Doc WITH (UPDLOCK, HOLDLOCK)
        WHERE Id_Tipo = @Id_TipoDocumento AND Estado_TiDoc = 'Activo';

        IF @Id_PedidoGenerado IS NULL OR @Id_DocumentoGenerado IS NULL
            THROW 50005, 'No se encontró un correlativo activo para la venta.', 1;

        IF EXISTS
        (
            SELECT 1
            FROM
            (
                SELECT Id_Pro, SUM(Cantidad) AS Cantidad
                FROM @Detalles
                GROUP BY Id_Pro
            ) d
            LEFT JOIN dbo.Productos p WITH (UPDLOCK, HOLDLOCK)
                ON p.Id_Pro = d.Id_Pro
            WHERE p.Id_Pro IS NULL
               OR p.Estado_Pro <> 'Activo'
               OR p.Stock_Actual < d.Cantidad
        )
            THROW 50006, 'Uno o más productos no existen, están inactivos o no tienen stock suficiente.', 1;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles d
            LEFT JOIN dbo.KardexProducto k WITH (UPDLOCK, HOLDLOCK)
                ON k.Id_Pro = d.Id_Pro AND k.EstadoKrdx = 'Activo'
            WHERE k.Id_krdx IS NULL
        )
            THROW 50007, 'Uno o más productos no tienen un Kardex activo.', 1;

        INSERT INTO dbo.Pedido
        (
            id_Ped, Id_Cliente, Fecha_Ped, SubTotal, IgvPed, TotalPed,
            id_Usu, TotalGancia, Total_Dscuento, Estado_Ped
        )
        VALUES
        (
            @Id_PedidoGenerado, @Id_Cliente, @FechaEmision, @SubTotal, @Igv,
            @TotalSoles, @Id_Usuario, @TotalGanancia, @TotalDescuento, 'Atendido'
        );

        INSERT INTO dbo.Detalle_Pedido
        (
            id_Ped, Id_Pro, Precio, Cantidad, Importe,
            Utilidad_Unit, TotalUtilidad, DescuentoDet
        )
        SELECT
            @Id_PedidoGenerado, Id_Pro, Precio, Cantidad, Importe,
            Utilidad_Unit, TotalUtilidad, DescuentoDet
        FROM @Detalles;

        INSERT INTO dbo.Documento
        (
            id_Doc, id_Ped, Id_Tipo, Fecha_Emi, ImporteDoc,
            TipoPago, Nro_Operacion, Id_Usu, TotalGanancia,
            TotalDscuento, Estado_Doc, CodigoMoneda, TipoCambio,
            ImporteMoneda, ImporteSoles
        )
        VALUES
        (
            @Id_DocumentoGenerado, @Id_PedidoGenerado, @Id_TipoDocumento,
            @FechaEmision, @TotalSoles, @TipoPago, @NroOperacion, @Id_Usuario,
            @TotalGanancia, @TotalDescuento, 'Activo', @CodigoMoneda,
            @TipoCambio, @ImporteMoneda, @TotalSoles
        );

        INSERT INTO dbo.Caja
        (
            Fecha_Caja, Tipo_Caja, Concepto, De_Para, Nro_Doc,
            ImporteCaja, Id_Usu, TotalUti, TipoPago, GeneradoPor,
            EstadoCaja, Total_Dscuentos, ModoCierre, CodigoMoneda,
            TipoCambio, ImporteMoneda, ImporteSoles
        )
        SELECT
            @FechaEmision, 'Entrada', 'Por Ventas al Público',
            c.Razon_Social_Nombres, @Id_DocumentoGenerado,
            @TotalSoles, @Id_Usuario, @TotalGanancia, @TipoPago,
            td.Documento, 'Activo', @TotalDescuento, 'Abierto',
            @CodigoMoneda, @TipoCambio, @ImporteMoneda, @TotalSoles
        FROM dbo.Cliente c
        CROSS JOIN dbo.Tipo_Doc td
        WHERE c.Id_Cliente = @Id_Cliente
          AND td.Id_Tipo = @Id_TipoDocumento;

        IF @@ROWCOUNT <> 1
            THROW 50008, 'No se pudo asociar el cliente o tipo de documento.', 1;

        ;WITH Cantidades AS
        (
            SELECT Id_Pro, SUM(Cantidad) AS Cantidad
            FROM @Detalles
            GROUP BY Id_Pro
        )
        UPDATE p
        SET p.Stock_Actual = p.Stock_Actual - c.Cantidad,
            p.Valor_porCant = (p.Stock_Actual - c.Cantidad) * p.Pre_CompraS
        FROM dbo.Productos p
        INNER JOIN Cantidades c ON c.Id_Pro = p.Id_Pro;

        ;WITH Cantidades AS
        (
            SELECT Id_Pro, SUM(Cantidad) AS Cantidad
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
            @FechaEmision,
            @Id_DocumentoGenerado,
            'Venta al público',
            0, 0, 0,
            c.Cantidad,
            p.Pre_CompraS,
            c.Cantidad * p.Pre_CompraS,
            p.Stock_Actual,
            p.Pre_CompraS,
            p.Stock_Actual * p.Pre_CompraS,
            @Id_Usuario,
            'Ventas',
            '-',
            0
        FROM Cantidades c
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
        WHERE Id_Tipo IN (4, @Id_TipoDocumento);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
