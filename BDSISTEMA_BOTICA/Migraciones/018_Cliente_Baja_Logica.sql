SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

USE [$(BaseDatos)];
GO

CREATE OR ALTER PROCEDURE dbo.Sp_DarBajar_Cliente
    @idcliente CHAR(10),
    @estado VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @idcliente = LTRIM(RTRIM(@idcliente));
    SET @estado = LTRIM(RTRIM(@estado));

    IF @idcliente IS NULL OR @idcliente = ''
        THROW 56031, 'Debe indicar el cliente.', 1;

    IF @estado NOT IN ('Activo', 'Eliminado')
        THROW 56032, 'El estado del cliente no es válido.', 1;

    IF @idcliente = 'C01' AND @estado = 'Eliminado'
        THROW 56033, 'El cliente predeterminado para venta al público no se puede desactivar.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE Id_Cliente = @idcliente
    )
        THROW 56034, 'El cliente indicado no existe.', 1;

    UPDATE dbo.Cliente
    SET Estado_Cli = @estado
    WHERE Id_Cliente = @idcliente;
END;
GO
