USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE dbo.Sp_Buscar_Cliente_porValor
    @Valor VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Filtro VARCHAR(250) = LTRIM(RTRIM(COALESCE(@Valor, '')));

    SELECT *
    FROM dbo.Cliente
    WHERE Estado_Cli = 'Activo'
      AND
      (
          @Filtro = ''
          OR DNI LIKE '%' + @Filtro + '%'
          OR Id_Cliente LIKE '%' + @Filtro + '%'
          OR Razon_Social_Nombres LIKE '%' + @Filtro + '%'
      )
    ORDER BY Razon_Social_Nombres ASC;
END;
GO

-- Corrige textos creados por versiones antiguas con codificación dañada.
UPDATE dbo.Caja
SET Concepto = N'Por Ventas al Público'
WHERE Concepto LIKE N'Por Ventas al P%blico'
  AND Concepto <> N'Por Ventas al Público';
GO

