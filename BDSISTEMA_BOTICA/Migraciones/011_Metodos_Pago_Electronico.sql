USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Los nombres profesionales de los medios de pago superan los 13 caracteres
-- que admitía el diseño original (por ejemplo, "Tarjeta crédito").
IF COL_LENGTH('dbo.Caja', 'TipoPago') IS NOT NULL
    ALTER TABLE dbo.Caja ALTER COLUMN TipoPago VARCHAR(50) NULL;
GO

IF COL_LENGTH('dbo.Temporal', 'TipoPago') IS NOT NULL
    ALTER TABLE dbo.Temporal ALTER COLUMN TipoPago VARCHAR(50) NULL;
GO

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
    @CodigoMoneda CHAR(3) = 'PEN',
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
        'Activo', @totaldescuento, 'Abierto', @CodigoMoneda,
        @TipoCambio,
        COALESCE(@ImporteMoneda, CONVERT(DECIMAL(18,2), @ImporteCaja)),
        COALESCE(@ImporteSoles, CONVERT(DECIMAL(18,2), @ImporteCaja))
    );
END;
GO

