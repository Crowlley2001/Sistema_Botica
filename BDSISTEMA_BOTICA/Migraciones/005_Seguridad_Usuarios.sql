USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET CONCAT_NULL_YIELDS_NULL ON;
GO

IF COL_LENGTH(N'dbo.Usuarios', N'PasswordHash') IS NULL
    ALTER TABLE dbo.Usuarios ADD PasswordHash VARBINARY(32) NULL;
GO

IF COL_LENGTH(N'dbo.Usuarios', N'PasswordSalt') IS NULL
    ALTER TABLE dbo.Usuarios ADD PasswordSalt VARBINARY(32) NULL;
GO

IF COL_LENGTH(N'dbo.Usuarios', N'PasswordIterations') IS NULL
    ALTER TABLE dbo.Usuarios ADD PasswordIterations INT NULL;
GO

CREATE OR ALTER VIEW dbo.V_Usuarios_Roles
AS
    SELECT
        u.Id_Usu,
        u.Nombres,
        u.Apellidos,
        CONCAT(u.Nombres, ' ', u.Apellidos) AS FullName,
        u.Usuario,
        CAST('PROTEGIDA' AS VARCHAR(10)) AS [Contraseña],
        u.FotoUsu,
        u.Id_Rol,
        r.Rol,
        u.Estado_Usu,
        u.Correo,
        u.Fecha_Ncmiento
    FROM dbo.Usuarios u
    INNER JOIN dbo.Roles r ON r.Id_Rol = u.Id_Rol;
GO

CREATE OR ALTER PROCEDURE dbo.sp_listar_Todos_users
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.V_Usuarios_Roles;
END;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Buscar_Usuario
    @idusu INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM dbo.V_Usuarios_Roles
    WHERE Id_Usu = @idusu;
END;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_LeerUsuario_Login
    @Usuario VARCHAR(50) = ''
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM dbo.V_Usuarios_Roles
    WHERE Usuario = @Usuario
      AND Estado_Usu = 'Activo';
END;
GO
