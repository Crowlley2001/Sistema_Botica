USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

SET XACT_ABORT ON;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    IF OBJECT_ID(N'dbo.TipoCambio', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.TipoCambio
        (
            Id_TipoCambio INT IDENTITY(1,1) NOT NULL
                CONSTRAINT PK_TipoCambio PRIMARY KEY,
            Fecha DATE NOT NULL,
            Compra DECIMAL(18,6) NOT NULL,
            Venta DECIMAL(18,6) NOT NULL,
            Id_Usu INT NULL,
            Estado VARCHAR(12) NOT NULL
                CONSTRAINT DF_TipoCambio_Estado DEFAULT ('ACTIVO')
        );
    END
    ELSE
    BEGIN
        ALTER TABLE dbo.TipoCambio ALTER COLUMN Compra DECIMAL(18,6) NOT NULL;
        ALTER TABLE dbo.TipoCambio ALTER COLUMN Venta DECIMAL(18,6) NOT NULL;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.check_constraints
        WHERE name = N'CK_TipoCambio_ValoresPositivos'
    )
    BEGIN
        ALTER TABLE dbo.TipoCambio WITH CHECK
        ADD CONSTRAINT CK_TipoCambio_ValoresPositivos
            CHECK (Compra > 0 AND Venta > 0 AND Compra <= Venta);
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.TipoCambio')
          AND name = N'UX_TipoCambio_Fecha_Activo'
    )
    BEGIN
        CREATE UNIQUE INDEX UX_TipoCambio_Fecha_Activo
            ON dbo.TipoCambio (Fecha)
            WHERE Estado = 'ACTIVO';
    END;

    IF COL_LENGTH(N'dbo.Documento', N'CodigoMoneda') IS NULL
        ALTER TABLE dbo.Documento ADD CodigoMoneda CHAR(3) NOT NULL
            CONSTRAINT DF_Documento_CodigoMoneda DEFAULT ('PEN') WITH VALUES;

    IF COL_LENGTH(N'dbo.Documento', N'TipoCambio') IS NULL
        ALTER TABLE dbo.Documento ADD TipoCambio DECIMAL(18,6) NOT NULL
            CONSTRAINT DF_Documento_TipoCambio DEFAULT (1) WITH VALUES;

    IF COL_LENGTH(N'dbo.Documento', N'ImporteMoneda') IS NULL
        ALTER TABLE dbo.Documento ADD ImporteMoneda DECIMAL(18,2) NULL;

    IF COL_LENGTH(N'dbo.Documento', N'ImporteSoles') IS NULL
        ALTER TABLE dbo.Documento ADD ImporteSoles DECIMAL(18,2) NULL;

    EXEC sys.sp_executesql N'
        UPDATE dbo.Documento
        SET ImporteMoneda = CONVERT(DECIMAL(18,2), ImporteDoc),
            ImporteSoles = CONVERT(DECIMAL(18,2), ImporteDoc)
        WHERE ImporteMoneda IS NULL OR ImporteSoles IS NULL;';

    IF COL_LENGTH(N'dbo.DocumentoCompras', N'CodigoMoneda') IS NULL
        ALTER TABLE dbo.DocumentoCompras ADD CodigoMoneda CHAR(3) NOT NULL
            CONSTRAINT DF_DocumentoCompras_CodigoMoneda DEFAULT ('PEN') WITH VALUES;

    IF COL_LENGTH(N'dbo.DocumentoCompras', N'TipoCambio') IS NULL
        ALTER TABLE dbo.DocumentoCompras ADD TipoCambio DECIMAL(18,6) NOT NULL
            CONSTRAINT DF_DocumentoCompras_TipoCambio DEFAULT (1) WITH VALUES;

    IF COL_LENGTH(N'dbo.DocumentoCompras', N'TotalMoneda') IS NULL
        ALTER TABLE dbo.DocumentoCompras ADD TotalMoneda DECIMAL(18,2) NULL;

    IF COL_LENGTH(N'dbo.DocumentoCompras', N'TotalSoles') IS NULL
        ALTER TABLE dbo.DocumentoCompras ADD TotalSoles DECIMAL(18,2) NULL;

    EXEC sys.sp_executesql N'
        UPDATE dbo.DocumentoCompras
        SET TotalMoneda = CONVERT(DECIMAL(18,2), Total_Ingre),
            TotalSoles = CONVERT(DECIMAL(18,2), Total_Ingre)
        WHERE TotalMoneda IS NULL OR TotalSoles IS NULL;';

    IF COL_LENGTH(N'dbo.Caja', N'CodigoMoneda') IS NULL
        ALTER TABLE dbo.Caja ADD CodigoMoneda CHAR(3) NOT NULL
            CONSTRAINT DF_Caja_CodigoMoneda DEFAULT ('PEN') WITH VALUES;

    IF COL_LENGTH(N'dbo.Caja', N'TipoCambio') IS NULL
        ALTER TABLE dbo.Caja ADD TipoCambio DECIMAL(18,6) NOT NULL
            CONSTRAINT DF_Caja_TipoCambio DEFAULT (1) WITH VALUES;

    IF COL_LENGTH(N'dbo.Caja', N'ImporteMoneda') IS NULL
        ALTER TABLE dbo.Caja ADD ImporteMoneda DECIMAL(18,2) NULL;

    IF COL_LENGTH(N'dbo.Caja', N'ImporteSoles') IS NULL
        ALTER TABLE dbo.Caja ADD ImporteSoles DECIMAL(18,2) NULL;

    EXEC sys.sp_executesql N'
        UPDATE dbo.Caja
        SET ImporteMoneda = CONVERT(DECIMAL(18,2), ImporteCaja),
            ImporteSoles = CONVERT(DECIMAL(18,2), ImporteCaja)
        WHERE ImporteMoneda IS NULL OR ImporteSoles IS NULL;';

    EXEC(N'
    CREATE OR ALTER PROCEDURE dbo.Sp_Insert_Documento
        @id_Doc CHAR(11),
        @id_Ped CHAR(11),
        @Id_Tipo INT,
        @Fecha_Emi DATETIME,
        @Importe REAL,
        @TipoPago VARCHAR(50),
        @NroOpera NCHAR(20),
        @id_Usu INT,
        @TotalGanancia REAL,
        @TotalDscuento REAL,
        @CodigoMoneda CHAR(3) = ''PEN'',
        @TipoCambio DECIMAL(18,6) = 1,
        @ImporteMoneda DECIMAL(18,2) = NULL,
        @ImporteSoles DECIMAL(18,2) = NULL
    AS
    BEGIN
        SET NOCOUNT ON;

        INSERT INTO dbo.Documento
        (
            id_Doc, id_Ped, Id_Tipo, Fecha_Emi, ImporteDoc,
            TipoPago, Nro_Operacion, Id_Usu, TotalGanancia,
            TotalDscuento, Estado_Doc, CodigoMoneda, TipoCambio,
            ImporteMoneda, ImporteSoles
        )
        VALUES
        (
            @id_Doc, @id_Ped, @Id_Tipo, @Fecha_Emi, @Importe,
            @TipoPago, @NroOpera, @id_Usu, @TotalGanancia,
            @TotalDscuento, ''Activo'', @CodigoMoneda, @TipoCambio,
            COALESCE(@ImporteMoneda, CONVERT(DECIMAL(18,2), @Importe)),
            COALESCE(@ImporteSoles, CONVERT(DECIMAL(18,2), @Importe))
        );
    END;');

    EXEC(N'
    CREATE OR ALTER PROCEDURE dbo.sp_registrar_Caja
        @Fecha_Caja DATETIME,
        @Tipo_Caja VARCHAR(50),
        @Concepto VARCHAR(190),
        @De_Para VARCHAR(180),
        @Nro_Doc CHAR(20),
        @ImporteCaja REAL,
        @Id_Usu INT,
        @TotalUti REAL,
        @TipoPago VARCHAR(50),
        @GeneradoPor VARCHAR(15),
        @totaldescuento REAL,
        @CodigoMoneda CHAR(3) = ''PEN'',
        @TipoCambio DECIMAL(18,6) = 1,
        @ImporteMoneda DECIMAL(18,2) = NULL,
        @ImporteSoles DECIMAL(18,2) = NULL
    AS
    BEGIN
        SET NOCOUNT ON;

        INSERT INTO dbo.Caja
        (
            Fecha_Caja, Tipo_Caja, Concepto, De_Para, Nro_Doc,
            ImporteCaja, Id_Usu, TotalUti, TipoPago, GeneradoPor,
            EstadoCaja, Total_Dscuentos, ModoCierre, CodigoMoneda,
            TipoCambio, ImporteMoneda, ImporteSoles
        )
        VALUES
        (
            @Fecha_Caja, @Tipo_Caja, @Concepto, @De_Para, @Nro_Doc,
            @ImporteCaja, @Id_Usu, @TotalUti, @TipoPago, @GeneradoPor,
            ''Activo'', @totaldescuento, ''Abierto'', @CodigoMoneda,
            @TipoCambio,
            COALESCE(@ImporteMoneda, CONVERT(DECIMAL(18,2), @ImporteCaja)),
            COALESCE(@ImporteSoles, CONVERT(DECIMAL(18,2), @ImporteCaja))
        );
    END;');

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
GO
