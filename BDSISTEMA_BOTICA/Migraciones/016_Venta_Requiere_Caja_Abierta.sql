USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO

CREATE OR ALTER TRIGGER dbo.TR_Caja_Venta_Requiere_Apertura
ON dbo.Caja
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        WHERE i.Tipo_Caja IN ('Entrada', 'Salida')
          AND i.ModoCierre = 'Abierto'
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.Cierre_Caja c WITH (UPDLOCK, HOLDLOCK)
              WHERE c.Id_Usu = i.Id_Usu
                AND c.Estado_cierre = 'Abierto'
                AND CONVERT(date, c.Fecha_Cierre) = CONVERT(date, GETDATE())
          )
    )
    BEGIN
        THROW 56016,
            'El movimiento requiere una caja abierta para el usuario actual.',
            1;
    END;
END;
GO
