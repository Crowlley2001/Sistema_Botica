USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Canjear_Nota_Venta
    @IdDocumentoOrigen CHAR(11),
    @IdTipoDocumentoNuevo INT,
    @FechaEmision DATETIME,
    @IdUsuario INT,
    @IdDocumentoNuevo VARCHAR(11) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @IdPedido CHAR(11);
    DECLARE @Importe DECIMAL(18,2);
    DECLARE @TipoPago VARCHAR(50);
    DECLARE @NroOperacion NCHAR(20);
    DECLARE @TotalGanancia DECIMAL(18,2);
    DECLARE @TotalDescuento DECIMAL(18,2);
    DECLARE @CodigoMoneda CHAR(3);
    DECLARE @TipoCambio DECIMAL(18,6);
    DECLARE @ImporteMoneda DECIMAL(18,2);
    DECLARE @ImporteSoles DECIMAL(18,2);
    DECLARE @DocumentoNuevo VARCHAR(50);

    IF @IdTipoDocumentoNuevo NOT IN (1, 2)
        THROW 57001, 'El canje solo puede generar factura o boleta.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT
            @IdPedido = d.id_Ped,
            @Importe = d.ImporteDoc,
            @TipoPago = d.TipoPago,
            @NroOperacion = d.Nro_Operacion,
            @TotalGanancia = d.TotalGanancia,
            @TotalDescuento = d.TotalDscuento,
            @CodigoMoneda = d.CodigoMoneda,
            @TipoCambio = d.TipoCambio,
            @ImporteMoneda = d.ImporteMoneda,
            @ImporteSoles = d.ImporteSoles
        FROM dbo.Documento d WITH (UPDLOCK, HOLDLOCK)
        WHERE d.id_Doc = @IdDocumentoOrigen
          AND d.Id_Tipo = 3
          AND d.Estado_Doc = 'Activo';

        IF @IdPedido IS NULL
            THROW 57002, 'La nota no existe, ya fue canjeada o no está activa.', 1;

        SELECT
            @IdDocumentoNuevo =
                RTRIM(Serie) + '-' + RIGHT('000000' + RTRIM(Numero), 6),
            @DocumentoNuevo = Documento
        FROM dbo.Tipo_Doc WITH (UPDLOCK, HOLDLOCK)
        WHERE Id_Tipo = @IdTipoDocumentoNuevo
          AND Estado_TiDoc = 'Activo';

        IF @IdDocumentoNuevo IS NULL
            THROW 57003, 'No existe correlativo activo para el nuevo comprobante.', 1;

        IF EXISTS
            (SELECT 1 FROM dbo.Documento WHERE id_Doc = @IdDocumentoNuevo)
            THROW 57004, 'El correlativo generado ya existe.', 1;

        INSERT INTO dbo.Documento
        (
            id_Doc, id_Ped, Id_Tipo, Fecha_Emi, ImporteDoc,
            TipoPago, Nro_Operacion, Id_Usu, TotalGanancia,
            TotalDscuento, Estado_Doc, CodigoMoneda, TipoCambio,
            ImporteMoneda, ImporteSoles
        )
        VALUES
        (
            @IdDocumentoNuevo, @IdPedido, @IdTipoDocumentoNuevo,
            @FechaEmision, @Importe, @TipoPago, @NroOperacion,
            @IdUsuario, @TotalGanancia, @TotalDescuento, 'Activo',
            ISNULL(@CodigoMoneda, 'PEN'), ISNULL(@TipoCambio, 1),
            ISNULL(@ImporteMoneda, @Importe), ISNULL(@ImporteSoles, @Importe)
        );

        UPDATE dbo.Documento
        SET Estado_Doc = 'Canjeado'
        WHERE id_Doc = @IdDocumentoOrigen;

        UPDATE dbo.Caja
        SET Nro_Doc = @IdDocumentoNuevo,
            GeneradoPor = @DocumentoNuevo
        WHERE RTRIM(Nro_Doc) = RTRIM(@IdDocumentoOrigen)
          AND EstadoCaja = 'Activo';

        UPDATE dbo.Tipo_Doc
        SET Numero =
            RIGHT('000000' + CONVERT(
                VARCHAR(6), CONVERT(INT, Numero) + 1), 6)
        WHERE Id_Tipo = @IdTipoDocumentoNuevo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
