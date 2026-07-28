USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    ALTER TABLE dbo.Miempresa ALTER COLUMN clavecorreo VARCHAR(1000) NULL;
    ALTER TABLE dbo.Miempresa ALTER COLUMN clavesol VARCHAR(1000) NULL;
    ALTER TABLE dbo.Miempresa ALTER COLUMN clavecertificado VARCHAR(1000) NULL;

    IF COL_LENGTH(N'dbo.Miempresa', N'RutaCertificado') IS NULL
        ALTER TABLE dbo.Miempresa ADD RutaCertificado VARCHAR(500) NULL;

    IF COL_LENGTH(N'dbo.Miempresa', N'AmbienteCpe') IS NULL
        ALTER TABLE dbo.Miempresa ADD AmbienteCpe VARCHAR(15) NOT NULL
            CONSTRAINT DF_Miempresa_AmbienteCpe
            DEFAULT ('PRUEBAS') WITH VALUES;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

CREATE OR ALTER PROCEDURE dbo.sp_EditarDatosEmpresa
    @nombreRancho VARCHAR(250),
    @nroRuc VARCHAR(20),
    @Direccionran VARCHAR(250),
    @correo VARCHAR(180),
    @usuariosol VARCHAR(50),
    @clavesol VARCHAR(1000),
    @clavecertificado VARCHAR(1000),
    @obs VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.Miempresa WHERE idrancho = 1)
    BEGIN
        UPDATE dbo.Miempresa
        SET nombreRancho = @nombreRancho,
            nroRuc = @nroRuc,
            Direccionran = @Direccionran,
            correo = @correo,
            usuariosol = @usuariosol,
            clavesol = @clavesol,
            clavecertificado = @clavecertificado,
            obs = @obs
        WHERE idrancho = 1;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.Miempresa
        (
            idrancho, nombreRancho, nroRuc, Direccionran, correo,
            usuariosol, clavesol, clavecertificado, obs
        )
        VALUES
        (
            1, @nombreRancho, @nroRuc, @Direccionran, @correo,
            @usuariosol, @clavesol, @clavecertificado, @obs
        );
    END;
END;
GO
