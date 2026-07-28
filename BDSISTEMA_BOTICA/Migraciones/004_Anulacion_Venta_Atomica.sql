USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Anular_Venta_Completa
    @IdDocumento CHAR(11),
    @DevolverStock BIT,
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @IdPedido CHAR(11);

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Usuarios WITH (UPDLOCK, HOLDLOCK)
            WHERE Id_Usu = @IdUsuario
              AND Id_Rol = 1
              AND Estado_Usu = 'Activo'
        )
            THROW 54005, 'Solo un administrador activo puede anular comprobantes.', 1;

        SELECT @IdPedido = id_Ped
        FROM dbo.Documento WITH (UPDLOCK, HOLDLOCK)
        WHERE id_Doc = @IdDocumento
          AND Estado_Doc = 'Activo';

        IF @IdPedido IS NULL
        BEGIN
            IF EXISTS
                (SELECT 1 FROM dbo.Documento WHERE id_Doc = @IdDocumento)
                THROW 54001, 'El comprobante ya está anulado o no se encuentra activo.', 1;

            THROW 54002, 'El comprobante indicado no existe.', 1;
        END;

        IF NOT EXISTS
            (SELECT 1 FROM dbo.Detalle_Pedido WHERE id_Ped = @IdPedido)
            THROW 54003, 'El comprobante no contiene detalle de productos.', 1;

        IF @DevolverStock = 1
        BEGIN
            IF EXISTS
            (
                SELECT 1
                FROM dbo.Detalle_Pedido d
                LEFT JOIN dbo.Productos p WITH (UPDLOCK, HOLDLOCK)
                    ON p.Id_Pro = d.Id_Pro
                LEFT JOIN dbo.KardexProducto k WITH (UPDLOCK, HOLDLOCK)
                    ON k.Id_Pro = d.Id_Pro AND k.EstadoKrdx = 'Activo'
                WHERE d.id_Ped = @IdPedido
                  AND (p.Id_Pro IS NULL OR k.Id_krdx IS NULL)
            )
                THROW 54004, 'No se puede devolver stock: falta el producto o su Kardex activo.', 1;

            ;WITH Devolucion AS
            (
                SELECT Id_Pro, SUM(CONVERT(DECIMAL(18,3), Cantidad)) AS Cantidad
                FROM dbo.Detalle_Pedido
                WHERE id_Ped = @IdPedido
                GROUP BY Id_Pro
            )
            UPDATE p
            SET p.Stock_Actual = p.Stock_Actual + d.Cantidad,
                p.Valor_porCant =
                    (p.Stock_Actual + d.Cantidad) * p.Pre_CompraS
            FROM dbo.Productos p
            INNER JOIN Devolucion d ON d.Id_Pro = p.Id_Pro;

            ;WITH Devolucion AS
            (
                SELECT Id_Pro, SUM(CONVERT(DECIMAL(18,3), Cantidad)) AS Cantidad
                FROM dbo.Detalle_Pedido
                WHERE id_Ped = @IdPedido
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
                GETDATE(),
                @IdDocumento,
                'Anulación de venta',
                d.Cantidad,
                p.Pre_CompraS,
                d.Cantidad * p.Pre_CompraS,
                0, 0, 0,
                p.Stock_Actual,
                p.Pre_CompraS,
                p.Stock_Actual * p.Pre_CompraS,
                @IdUsuario,
                'Anulacion',
                '-',
                0
            FROM Devolucion d
            INNER JOIN dbo.Productos p ON p.Id_Pro = d.Id_Pro
            INNER JOIN dbo.KardexProducto k
                ON k.Id_Pro = d.Id_Pro AND k.EstadoKrdx = 'Activo'
            OUTER APPLY
            (
                SELECT MAX(dk.Item) AS UltimoItem
                FROM dbo.Detalle_Kardex dk WITH (UPDLOCK, HOLDLOCK)
                WHERE dk.Id_krdx = k.Id_krdx
            ) ultimo;
        END;

        UPDATE dbo.Documento
        SET Estado_Doc = 'Anulado'
        WHERE id_Doc = @IdDocumento;

        UPDATE dbo.Pedido
        SET Estado_Ped = 'Anulado'
        WHERE id_Ped = @IdPedido;

        UPDATE dbo.Caja
        SET EstadoCaja = 'Anulado'
        WHERE RTRIM(Nro_Doc) = RTRIM(@IdDocumento)
          AND ISNULL(EstadoCaja, '') <> 'Anulado';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
