

-- INSERT
CREATE PROC sp_registrar_Prod_ventaPerdia
(
@idprod CHAR(20),
@idusu INT,
@motiviIngre VARCHAR(15)
)
AS
INSERT INTO ProductosSinValor
VALUES
(
    @idprod,
    @idusu,
    GETDATE(),
    @motiviIngre
)
GO

-- VISTA
CREATE VIEW V_ProductosinValor_Prod
AS
SELECT
    v.idPrCon,
    v.FecharegProd,
    v.motivoIngre,
    p.Id_Pro,
    p.Descripcion_Larga,
    p.Stock_Actual,
    u.Id_Usu,
    u.Nombres,
    u.Id_Rol
FROM ProductosSinValor v,
     productos p,
     usuarios u
WHERE
    v.Id_Pro = p.Id_Pro
    AND v.Id_Usu = u.Id_Usu
GO



create Proc sp_VerProducto_NoVendidos_pornoTenerStock
@fechadia date
As
Select * from V_ProductosinValor_Prod
Where
DATEPART (YEAR,FecharegProd)= DATEPART (YEAR,@fechadia) AND
DATEPART (DAYOFYEAR,FecharegProd)= DATEPART (DAYOFYEAR,@fechadia)
Go



CREATE PROC sp_VerProducto_NoVendidos_pornoTenerStock_porfechas
(
@fecha1 DATE,
@fecha2 DATE
)
AS
SELECT *
FROM V_ProductosinValor_Prod
WHERE FecharegProd BETWEEN @fecha1 AND @fecha2
ORDER BY FecharegProd ASC
GO


















create Proc Sp_Ver_Kardex_delDia
@Fecha date
As
Select * from V_Kardex_Detalle
Where
DATEPART (YEAR,Fecha_Krdx)= DATEPART (YEAR,@Fecha) AND
DATEPART (DAYOFYEAR,Fecha_Krdx)= DATEPART (DAYOFYEAR,@Fecha)
Go