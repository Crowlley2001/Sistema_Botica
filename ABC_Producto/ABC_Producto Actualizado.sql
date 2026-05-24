
use BDSISTEMA_BOTICA
go

alter table productos add CampoReporte varchar (15)
go
update Productos set
CampoReporte = 'Nada'
go


--ALTER TABLE Productos ALTER COLUMN FechaVncmnto varchar (11)  --Codigo para Cambiar tipo de dato de un campo
--go
--------Asi debe quedar - Cambia el nombre del acolumna de la tabla Productos:
--EXEC sp_rename 'Productos.Cant_xFc', 'PreVenta2', 'COLUMN';  
--GO
--Modificamos la Tabla Productos:

--insert:
alter procedure Sp_registrar_Producto (
@idpro char (20),
@descripcion varchar (150),
@Pre_compra real,
@StockActual real,
@idCat int,
@Foto varchar (180),
@Pre_Venta real,
@Frmto_Compra char (10),
@Utilidad real,
@ValorporProd real,
---Estado
@Laboratorio varchar (20),
@Prin_Activo varchar (20),
@Und_Min int,
@Und_Max int,
--Por defecto
@Ventaconreceta varchar (20),
@fechaVncmnto varchar (11)
)
As
Insert into Productos values (
@idpro ,
@descripcion,
@Pre_compra,
@StockActual ,
@idCat ,
@Foto ,
@Pre_Venta,
@Frmto_Compra,
@Utilidad ,
@ValorporProd ,
'Activo',
@Laboratorio ,
@Prin_Activo ,
@Und_Min ,
@Und_Max ,
GETDATE(),
@Ventaconreceta,
@fechaVncmnto,
0,
'Nada'
)
go


--update:
create procedure Sp_Editar_Producto (
@idpro char (20),
@descripcion varchar (150),
@Pre_compra real,
@idCat int,
@Foto varchar (180),
@Pre_Venta real,
@Frmto_Compra varchar (10),
---Estado
@Prin_Activo varchar (20),
@Laboratorio varchar (20),
@Und_Min int,
@Und_Max int,
---Por defecto
@fechaVncmnto varchar (11),
@Ventaconreceta varchar (20)
)
As
Update Productos set
Descripcion_Larga=@descripcion ,
Pre_CompraS=@Pre_compra ,
Id_Cat=@idCat ,
Foto=@Foto ,
Pre_Venta =@Pre_Venta ,
Frmto_Compra =@Frmto_Compra ,
Prin_Acti=@Prin_Activo,
Laboratorio=@laboratorio,
Und_Min=@Und_Min ,
Und_Max=@Und_Max ,
FechaVncmnto =@fechaVncmnto ,
VentaConReceta=@Ventaconreceta 
where
Id_Pro =@idpro 
go

--Unimos Las Tablas en Vistas:
alter view v_Producto_Categoria
As
select 
P.id_Pro,
p.Descripcion_Larga ,
p.Pre_CompraS ,
p.Stock_Actual ,
p.Foto ,
p.Pre_venta  ,
p.Frmto_Compra  ,
p.UtilidadUnit,
p.Valor_porCant  ,
p.Estado_Pro, p.Prin_Acti, p.Laboratorio, p.Und_Min , p.Und_Max , p.FechaIngreso , p.FechaVncmnto ,
p.VentaConReceta , p.comisionporcen, p.CampoReporte,
c.Id_Cat , c.Categoria 
from Productos p,  Categorias c
where
p.Id_Cat = c.Id_Cat
go




---sp de consulta
create procedure sp_Listar_Todos_Productos
AS
select * from
v_Producto_Categoria
order by Descripcion_Larga Asc
go


--Busqueda de producto:
Create proc Sp_Buscador_Produtos_porValor (
@valor varchar (150)
)
As
Select * from v_Producto_Categoria
where
Id_Pro =@valor or
Descripcion_Larga like '%' + @valor + '%' or
Prin_Acti like '%' + @valor + '%' or
Laboratorio like '%' + @valor + '%'
go


-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------

--Productos con Stock por debajo del Minimo:
create procedure sp_cargar_Todos_Productos_conminimoStock
As
select * from v_Productos_yDependientes
where
Estado_Pro ='Activo' and
Stock_Actual <= Und_Min
order by Descripcion_Larga Asc
go


--Todoslos productos:
create procedure sp_cargar_Todos_Productos
As
select * from v_Productos_yDependientes
where
Estado_Pro ='Activo'
order by Descripcion_Larga Asc
go

--2 para llevar lista con stock y precio compra y venta
create procedure sp_cargar_Todos_Productos_stockPrecompra_Venta
As
select * from v_Productos_yDependientes
where
Estado_Pro ='Activo' and
Stock_Actual > 0
order by Descripcion_Larga Asc
go


create proc [dbo].[Sp_Buscador_Produtos_porValor] (
@valor varchar (150)
)
As
Select * from v_Producto_Categoria
where
Estado_Pro ='Activo' and
Id_Pro =@valor or
Descripcion_Larga like '%' + @valor + '%' or
Prin_Acti like '%' + @valor + '%' or
Laboratorio like '%' + @valor + '%'
go



exec Sp_buscador_Productos '0011232'
go

--Eliminar:
Create Procedure Sp_Darbaja_Producto (
@idpro char (20)
)
as
update Productos set
Estado_Pro ='Eliminado'
where
Id_Pro =@idpro 
go

create procedure sp_Eliminar_Producto(
@idpro char (20),
@idKarde char (11)
)
As
Delete from Detalle_Kardex where Id_krdx =@idKarde 
Delete from KardexProducto where Id_krdx =@idKarde 
Delete from Productos where Id_Pro =@idpro 
go

--Para el Control de Inventario:
Create procedure sp_SumarStock (
@idpro char (20),
@stock real
)
as
update Productos set
Stock_Actual = Stock_Actual + @stock 
where
Id_Pro =@idpro 
go

Create procedure sp_Restar_Stock (
@idpro char (20),
@stock real
)
as
update Productos set
Stock_Actual = Stock_Actual - @stock 
where
Id_Pro =@idpro 
go


--Especial para Igualar stock a Cero:
Create procedure sp_Igualar_Stock_aCero (
@idpro char (20),
@stock real
)
as
update Productos set
Stock_Actual = @stock
where
Id_Pro =@idpro 
go

--Cuando hacemos el Ingreso de nuevos Productos..  Es Posible que el Precio de compra tenga variacioens.. y tenemos que hacer que
--el sistema actualice esos precios..de forma automatica:
create procedure Sp_Actulizar_Precios_CompraVenta_Producto  
(
@Id_Pro char (20),
@Pre_CompraS real,
@Pre_vntaxMenor real,
@Utilidad real,
@ValorAlmacen Real
)
as
update  Productos   set 
Pre_CompraS =@Pre_CompraS ,
Pre_venta =@Pre_vntaxMenor ,
UtilidadUnit =@Utilidad ,
Valor_porCant = @ValorAlmacen
where Id_Pro =@Id_Pro 
go

--caluclar valor de almacen:
create procedure sp_calcular_Valor_almacen (
@idpro char (20)
)
as
update Productos set
Valor_porCant = Stock_Actual * Pre_CompraS
where
Id_Pro =@idpro 
go



create procedure sp_calcular_utilidad (
@idpro char (20)
)
as
update Productos set
Valor_porCant = Pre_venta - Pre_CompraS
where
Id_Pro =@idpro 
go

--actualizar sotck y precios
Create procedure Sp_Actulizar_Precios_CompraVenta_yStock
(
@Id_Pro char (20),
@Pre_CompraS real,
@stock real,
@Pre_vntaxMenor real,
@comision real
)
as
update  Productos   set 
Pre_CompraS =@Pre_CompraS ,
Stock_Actual= @stock ,
Pre_vntaxMenor =@Pre_vntaxMenor,
comisionporcen=@comision
where 
Id_Pro =@Id_Pro 
go


--nuevo:
Create procedure sp_cargar_Todos_Productos_conStock
As
select * from v_Productos_yDependientes
where
Estado_Pro ='Activo' and
Stock_Actual > 0 
order by Descripcion_Larga Asc
Go

--2:
create Procedure Sp_buscador_Productos_conStock(
@valor varchar (150)
)
As
Select * from v_Productos_yDependientes Where
Laboratorio = @valor and
Stock_Actual > 0 and
Estado_Pro ='Activo' or
Id_Pro =@valor or
Prin_Acti=@valor or
Categoria =@valor and
Laboratorio = @valor and
Stock_Actual > 0 and
Estado_Pro ='Activo'
order by Descripcion_Larga Asc
go

exec Sp_buscador_Productos_conStock 'MEDIFARMA'
go


--==== nurevo SP para no interferir con los otros
--actualizar sotck y precios
Create procedure Sp_Actulizar_Precios_CompraVenta_Importado
(
@Id_Pro char (20),
@Pre_CompraS real,
@Pre_vntaxMenor real,
@comision real
)
as
update  Productos   set 
Pre_CompraS =@Pre_CompraS ,
Pre_venta =@Pre_vntaxMenor,
comisionporcen=@comision
where 
Id_Pro =@Id_Pro 
go

--Eliminar:
create procedure Sp_Cambiar_CampoReporteProducto(
@idpro char (20),
@Palabra varchar (15)
)
as
update Productos set 
CampoReporte = @Palabra
where
Id_Pro = @idpro
go


Create Procedure Sp_Verificar_siProducto_TieneVenta (
@idprod char(20),
@fecha date
)
as
Select count(*) from V_Listado_Pedido_Detalle
    where 
    Id_Pro = @idprod and
    DATEPART(YEAR, Fecha_Ped) = DATEPART(YEAR, @fecha) and
    DATEPART(MONTH, Fecha_Ped) = DATEPART(MONTH, @fecha)
go


Create Proc Sp_Listar_productos_sinRotacion
@Palabra varchar(15)
As
select * from V_Producto_Categoria
where 
CampoReporte = @Palabra
go





create view V_Ventas_Detalle
as
select
Doc.id_Doc,
Doc.Fecha_Emi,
Ped.id_Ped,
Det.Id_Pro,
Pro.Descripcion_Larga,
Det.Cantidad,
Det.Importe
from Documento Doc
inner join Pedido Ped on Doc.id_Ped = Ped.id_Ped
inner join Detalle_Pedido Det on Ped.id_Ped = Det.id_Ped
inner join Productos Pro on Det.Id_Pro = Pro.Id_Pro
go




CREATE PROCEDURE Sp_Productos_MasVendidos_DelDia
@Fecha DATE
AS
BEGIN

SELECT 
    Id_Pro,
    Descripcion_Larga,
    SUM(Cantidad) AS Cantidad,
    CAST(SUM(Importe) AS DECIMAL(10,2)) AS Importe
FROM V_Ventas_Detalle
WHERE CAST(Fecha_Emi AS DATE) = @Fecha
GROUP BY
    Id_Pro,
    Descripcion_Larga
ORDER BY
    SUM(Cantidad) DESC

END
go

create procedure sp_productos_reposicion
As
select 
    Id_Pro,
    Descripcion_Larga,
    Stock_Actual,
    Und_Min,
    (Und_Min - Stock_Actual) as CantidadComprar
from Productos
where 
    Estado_Pro = 'Activo' 
    and Stock_Actual <= Und_Min
order by Descripcion_Larga asc
go

select * from Productos 
select * from Cliente
select * from KardexProducto
go

