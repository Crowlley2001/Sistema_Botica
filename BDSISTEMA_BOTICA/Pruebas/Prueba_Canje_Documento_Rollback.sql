USE [$(BaseDatos)];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @DocumentoOrigen CHAR(11);
DECLARE @Usuario INT;
DECLARE @DocumentoNuevo VARCHAR(11);
DECLARE @NumeroAntes VARCHAR(20);
DECLARE @FechaPrueba DATETIME = GETDATE();

SELECT TOP (1)
    @DocumentoOrigen = d.id_Doc,
    @Usuario = d.Id_Usu
FROM dbo.Documento d
WHERE d.Id_Tipo = 3
  AND d.Estado_Doc = 'Activo'
ORDER BY d.Fecha_Emi DESC;

SELECT @NumeroAntes = RTRIM(Numero)
FROM dbo.Tipo_Doc
WHERE Id_Tipo = 2
  AND Estado_TiDoc = 'Activo';

IF @DocumentoOrigen IS NULL OR @NumeroAntes IS NULL
    THROW 58001, 'No existe una nota activa o correlativo para probar el canje.', 1;

BEGIN TRANSACTION;

EXEC dbo.Sp_Canjear_Nota_Venta
    @IdDocumentoOrigen = @DocumentoOrigen,
    @IdTipoDocumentoNuevo = 2,
    @FechaEmision = @FechaPrueba,
    @IdUsuario = @Usuario,
    @IdDocumentoNuevo = @DocumentoNuevo OUTPUT;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Documento
    WHERE id_Doc = @DocumentoOrigen
      AND Estado_Doc = 'Canjeado'
)
    THROW 58002, 'La nota original no quedó marcada como canjeada.', 1;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Documento
    WHERE id_Doc = @DocumentoNuevo
      AND Id_Tipo = 2
      AND Estado_Doc = 'Activo'
)
    THROW 58003, 'No se generó la nueva boleta.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Caja
    WHERE RTRIM(Nro_Doc) = RTRIM(@DocumentoOrigen)
      AND EstadoCaja = 'Activo'
)
    THROW 58004, 'Caja todavía apunta a la nota original.', 1;

SELECT
    RTRIM(@DocumentoOrigen) AS NotaOrigen,
    @DocumentoNuevo AS BoletaGenerada,
    'PRUEBA CORRECTA: se revertirá el canje' AS Resultado;

ROLLBACK TRANSACTION;

IF EXISTS (SELECT 1 FROM dbo.Documento WHERE id_Doc = @DocumentoNuevo)
    THROW 58005, 'El rollback dejó el nuevo comprobante.', 1;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Documento
    WHERE id_Doc = @DocumentoOrigen
      AND Estado_Doc = 'Activo'
)
    THROW 58006, 'El rollback no restauró la nota original.', 1;

IF EXISTS
(
    SELECT 1
    FROM dbo.Tipo_Doc
    WHERE Id_Tipo = 2
      AND RTRIM(Numero) <> @NumeroAntes
)
    THROW 58007, 'El rollback no restauró el correlativo.', 1;

SELECT 'ROLLBACK VERIFICADO: la base quedó sin cambios de prueba' AS ResultadoFinal;
GO
