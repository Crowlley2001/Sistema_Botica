USE [$(BaseDatos)];
GO

SET NOCOUNT ON;

UPDATE dbo.Caja
SET Concepto = N'Por Ventas al Público'
WHERE Concepto LIKE N'%Ventas al%'
  AND Concepto LIKE N'%blico%'
  AND Concepto <> N'Por Ventas al Público';

UPDATE dbo.Detalle_Kardex
SET Det_Operacion = 'Venta al Público'
WHERE Det_Operacion LIKE '%Venta al%'
  AND Det_Operacion LIKE '%blico%'
  AND Det_Operacion <> 'Venta al Público';
GO

