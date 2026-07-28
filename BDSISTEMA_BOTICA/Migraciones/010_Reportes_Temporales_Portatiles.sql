:setvar BaseDatos "BDSISTEMA_BOTICA"
GO

USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    IF COL_LENGTH(N'dbo.Temporal', N'CodigoQr') IS NOT NULL
       AND EXISTS
       (
           SELECT 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID(N'dbo.Temporal')
             AND name = N'CodigoQr'
             AND system_type_id = TYPE_ID(N'varbinary')
       )
    BEGIN
        ALTER TABLE dbo.Temporal ALTER COLUMN CodigoQr VARCHAR(500) NULL;
    END;

    EXEC(N'
    CREATE OR ALTER PROCEDURE dbo.Sp_Insertar_Temporal
        @codTem NCHAR(12),
        @FechaEmi VARCHAR(20),
        @cliente VARCHAR(150),
        @Ruc VARCHAR(50),
        @Direccion VARCHAR(150),
        @SubTtal VARCHAR(50),
        @IgvT VARCHAR(50),
        @TotalT VARCHAR(50),
        @TotalDscto VARCHAR(50),
        @SonT VARCHAR(200),
        @vendedor VARCHAR(120),
        @CodigoQr VARCHAR(500),
        @Tipocomprobante VARCHAR(50),
        @HashCpe VARCHAR(60),
        @MotivoEmi VARCHAR(60),
        @TipoPago VARCHAR(50)
    AS
    BEGIN
        SET NOCOUNT ON;
        SET XACT_ABORT ON;

        BEGIN TRANSACTION;

        DELETE FROM dbo.Detalle_Temporal
        WHERE CodTem = @codTem;

        DELETE FROM dbo.Temporal
        WHERE CodTem = @codTem;

        INSERT INTO dbo.Temporal
        (
            CodTem, FechaEmi, cliente, Ruc, Direccion, SubTtal, IgvT,
            TotalT, TotalDscto, SonT, Vendedor, CodigoQr,
            Tipocomprobante, HashCpe, MotivoEmi, TipoPago,
            DireccionTienda, NombreSucursal
        )
        VALUES
        (
            @codTem, @FechaEmi, @cliente, @Ruc, @Direccion, @SubTtal,
            @IgvT, @TotalT, @TotalDscto, @SonT, @vendedor, @CodigoQr,
            @Tipocomprobante, @HashCpe, @MotivoEmi, @TipoPago, '''', ''''
        );

        COMMIT TRANSACTION;
    END;');

    EXEC(N'
    CREATE OR ALTER VIEW dbo.V_Temporales_Detalle
    AS
    SELECT
        T.CodTem,
        T.FechaEmi,
        T.Cliente,
        T.Ruc,
        T.Direccion,
        T.SubTtal,
        T.IgvT,
        T.TotalT,
        T.SonT,
        T.Vendedor,
        T.CodigoQr,
        T.Tipocomprobante,
        T.HashCpe,
        T.MotivoEmi,
        T.TipoPago,
        D.CodPro,
        D.Producto,
        D.Pre_Unt,
        D.ImporteT,
        D.Cantidad
    FROM dbo.Temporal AS T
    INNER JOIN dbo.Detalle_Temporal AS D
        ON D.CodTem = T.CodTem
    WHERE LTRIM(RTRIM(T.CodTem)) <> ''''
      AND LTRIM(RTRIM(D.CodPro)) <> '''';');

    EXEC(N'
    CREATE OR ALTER PROCEDURE dbo.Sp_Listar_Temporales
        @id NCHAR(12)
    AS
    BEGIN
        SET NOCOUNT ON;

        SELECT *
        FROM dbo.V_Temporales_Detalle
        WHERE LTRIM(RTRIM(CodTem)) = LTRIM(RTRIM(@id));
    END;');

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
