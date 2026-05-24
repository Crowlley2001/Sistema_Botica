use BDSISTEMA_BOTICA

CREATE TABLE [dbo].[TipoCambio](
	[Id_TipoCambio] INT IDENTITY(1,1) NOT NULL,
	[Fecha] DATE NOT NULL,
	[Compra] REAL NOT NULL,
	[Venta] REAL NOT NULL,
	[Id_Usu] INT NULL,
	[Estado] VARCHAR(12) NULL,

	CONSTRAINT PK_TipoCambio PRIMARY KEY ([Id_TipoCambio])
)
GO



INSERT INTO TipoCambio (Fecha, Compra, Venta, Id_Usu, Estado)
VALUES ('2025-12-27', 3.70, 3.75, 1, 'ACTIVO')
INSERT INTO TipoCambio (Fecha, Compra, Venta, Id_Usu, Estado)
VALUES ('2026-03-17', 12, 15, 1, 'ACTIVO')

CREATE PROCEDURE Sp_Guardar_TipoCambio
@Fecha DATE,
@Compra REAL,
@Venta REAL,
@Id_Usu INT
AS
BEGIN
    INSERT INTO TipoCambio (Fecha, Compra, Venta, Id_Usu, Estado)
    VALUES (@Fecha, @Compra, @Venta, @Id_Usu, 'ACTIVO')
END
GO


CREATE PROCEDURE Sp_Buscar_TipoCambio_Fecha
@Fecha DATE
AS
BEGIN
	SELECT TOP 1 *
	FROM TipoCambio
	WHERE Fecha = @Fecha
END
GO

CREATE PROCEDURE Sp_Listar_TipoCambio
AS
BEGIN
	SELECT * FROM TipoCambio
	ORDER BY Fecha DESC
END
GO

CREATE PROCEDURE SP_EXISTE_TIPO_CAMBIO
    @Fecha DATE,
    @Existe BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM TipoCambio WHERE Fecha = @Fecha AND Estado = 'ACTIVO')
        SET @Existe = 1
    ELSE
        SET @Existe = 0
END
GO


CREATE PROCEDURE Sp_TipoCambio_Actual
AS
BEGIN
    SELECT TOP 1 *
    FROM TipoCambio
    WHERE Estado = 'ACTIVO'
    ORDER BY Fecha DESC
END
GO


SELECT * FROM TipoCambio 
SELECT * FROM Roles