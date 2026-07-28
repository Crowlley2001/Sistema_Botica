USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO

-- Conserva las relaciones existentes: no elimina categorías que puedan estar
-- asociadas a productos, sino que corrige sus nombres vacíos.
UPDATE dbo.Categorias
SET Categoria = N'Sin categoría'
WHERE NULLIF(LTRIM(RTRIM(Categoria)), N'') IS NULL;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE parent_object_id = OBJECT_ID(N'dbo.Categorias')
      AND name = N'CK_Categorias_NombreNoVacio'
)
BEGIN
    ALTER TABLE dbo.Categorias WITH CHECK
    ADD CONSTRAINT CK_Categorias_NombreNoVacio
        CHECK (NULLIF(LTRIM(RTRIM(Categoria)), N'') IS NOT NULL);
END;
GO
