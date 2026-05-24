

USE BDSISTEMA_BOTICA
GO

ALTER PROCEDURE sp_EditarDatosEmpresa
(
@nombreRancho varchar(100),
@nroRuc varchar(20),
@Direccionran varchar(200),
@correo varchar(100),
@usuariosol varchar(50),
@clavesol varchar(50),
@clavecertificado varchar(100),
@obs varchar(250)
)
AS
BEGIN

IF EXISTS (SELECT * FROM Miempresa WHERE idrancho = 1)
BEGIN

UPDATE Miempresa
SET
nombreRancho = @nombreRancho,
nroRuc = @nroRuc,
Direccionran = @Direccionran,
correo = @correo,
usuariosol = @usuariosol,
clavesol = @clavesol,
clavecertificado = @clavecertificado,
obs = @obs
WHERE idrancho = 1

END
ELSE
BEGIN

INSERT INTO Miempresa
(
idrancho,
nombreRancho,
nroRuc,
Direccionran,
correo,
usuariosol,
clavesol,
clavecertificado,
obs
)
VALUES
(
1,
@nombreRancho,
@nroRuc,
@Direccionran,
@correo,
@usuariosol,
@clavesol,
@clavecertificado,
@obs
)

END
END

select * from Miempresa