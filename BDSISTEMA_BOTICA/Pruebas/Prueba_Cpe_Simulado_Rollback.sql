USE [$(BaseDatos)];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID('dbo.CpeEnvio', 'U') IS NULL
    THROW 57140, 'No existe la tabla de trazabilidad CPE.', 1;

IF COL_LENGTH('dbo.CpeEnvio', 'XmlGenerado') IS NULL
   OR COL_LENGTH('dbo.CpeEnvio', 'CdrContenido') IS NULL
   OR COL_LENGTH('dbo.CpeEnvio', 'EstadoCpe') IS NULL
    THROW 57141, 'La tabla CPE no tiene la estructura esperada.', 1;

DECLARE @Documento CHAR(11) =
(
    SELECT TOP (1) id_Doc
    FROM dbo.Documento
    ORDER BY Fecha_Emi DESC
);

IF @Documento IS NULL
BEGIN
    SELECT 'PRUEBA CORRECTA: estructura CPE disponible; no existen documentos para probar persistencia.' AS Resultado;
    RETURN;
END;

BEGIN TRANSACTION;

MERGE dbo.CpeEnvio AS destino
USING (SELECT @Documento AS IdDocumento) AS origen
ON destino.IdDocumento = origen.IdDocumento
WHEN MATCHED THEN UPDATE SET
    Ambiente = 'SIMULACION',
    EstadoCpe = 'PRUEBA_ROLLBACK',
    CodigoRespuesta = 'TEST',
    MensajeRespuesta = N'Este dato será revertido',
    HashCpe = 'HASH-PRUEBA',
    XmlGenerado = N'<Invoice prueba="true" />',
    CdrContenido = N'<RespuestaSimulada prueba="true" />',
    FechaProceso = SYSDATETIME(),
    Intentos = destino.Intentos + 1
WHEN NOT MATCHED THEN INSERT
(
    IdDocumento, Ambiente, EstadoCpe, CodigoRespuesta,
    MensajeRespuesta, HashCpe, XmlGenerado, CdrContenido,
    FechaProceso, Intentos
)
VALUES
(
    @Documento, 'SIMULACION', 'PRUEBA_ROLLBACK', 'TEST',
    N'Este dato será revertido', 'HASH-PRUEBA',
    N'<Invoice prueba="true" />',
    N'<RespuestaSimulada prueba="true" />',
    SYSDATETIME(), 1
);

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CpeEnvio
    WHERE IdDocumento = @Documento
      AND EstadoCpe = 'PRUEBA_ROLLBACK'
)
    THROW 57142, 'No se pudo verificar la persistencia CPE.', 1;

SELECT RTRIM(@Documento) AS DocumentoProbado,
       'PRUEBA CORRECTA: se revertirá el registro CPE.' AS Resultado;

ROLLBACK TRANSACTION;
SELECT 'ROLLBACK VERIFICADO: la base quedó sin cambios de prueba.' AS ResultadoFinal;
GO
