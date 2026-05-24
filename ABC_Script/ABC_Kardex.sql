use BDSISTEMA_BOTICA
go



create Proc Sp_Ver_sihay_Kardex
@Id_Prod char (20)
As
select COUNT (*) from KardexProducto
where
Id_Pro =@Id_Prod 
Go

exec Sp_Ver_sihay_Kardex 'jfhfe'
go

--insert:
Create procedure sp_crear_kardex(
@idkardex char (11),
@idprod char (20)
)
as
insert into KardexProducto values (
@idkardex ,
@idprod ,
GETDATE() ,
'Activo'
)
go

--detalle del Kardex:
create procedure Sp_registrar_detalle_kardex(
@Id_Krdx char (11),
@Item int,
@Doc_Soport nchar (20),
@Det_Operacion varchar (180),
--entrada
@Cantidad_In Real,
@Precio_Unt_In Real,
@Costo_Total_In Real,
--salida
@Cantidad_Out Real,
@Precio_Unt_Out Real,
@Importe_Total_Out Real,
--saldo
@Cantidad_Saldo Real,
@Promedio Real,
@Costo_Total_Saldo Real,
--Adicionales:
@id_usu int,
@Tipo_operacion varchar (17),  --perdida
@Cant_Difncial varchar (10),  --2
@ImportDiferen real --20.0
)
as
insert into Detalle_Kardex values (
@Id_Krdx ,
@Item ,
GETDATE(),
@Doc_Soport ,
@Det_Operacion ,
--entrada
@Cantidad_In ,
@Precio_Unt_In ,
@Costo_Total_In ,
--salida
@Cantidad_Out ,
@Precio_Unt_Out ,
@Importe_Total_Out ,
--saldo
@Cantidad_Saldo ,
@Promedio ,
@Costo_Total_Saldo ,
@id_usu,
@Tipo_operacion,
@Cant_Difncial,
@ImportDiferen
)
go



Create View [dbo].[V_Kardex_Detalle]
AS
SELECT 
KR.Id_krdx , KR.EstadoKrdx ,
DT.Item, DT.Fecha_Krdx , DT.Doc_Soporte , DT.Det_Operacion , DT.Cantidad_In , DT.Precio_In , DT.Total_In ,
DT.Cantidad_Out , DT.Precio_Out , DT.Total_Out , DT.Cantidad_Saldo , DT.Promedio , DT.Costo_Total_Saldo ,
DT.Tipo_operacion,DT.Cant_Difncial , DT.ImportDiferen ,
PR.Id_Pro , PR.Descripcion_Larga , PR.Stock_Actual ,
u.Id_Usu , u.Nombres , u.Id_Rol 
FROM KardexProducto KR , Detalle_Kardex  DT , Productos PR , Usuarios u
WHERE 
KR.Id_krdx = DT.Id_krdx AND
KR.Id_Pro = PR.Id_Pro and
DT.Id_Usu=u.Id_Usu 
GO

create Proc Sp_Buscador_DeKardex_Principal_yDetalle
@xvalor varchar (180) 
As
Select * from V_Kardex_Detalle
Where
Id_Pro = @xvalor  or
Doc_Soporte = @xvalor  or
Id_krdx = @xvalor  or
Tipo_operacion=@xvalor or
Descripcion_Larga  like @xvalor + '%' or Descripcion_Larga + '%' like @xvalor  + '%'
Order by Item Asc
Go

exec Sp_Buscador_DeKardex_Principal_yDetalle 'PROD-8520'
go

select * from KardexProducto 
where Id_Pro = 'PROD-00789'
go

select * from Detalle_Kardex 
go


create Proc Sp_Ver_Kardex_delDia
@Fecha date
As
Select * from V_Kardex_Detalle
Where
DATEPART (YEAR,Fecha_Krdx)= DATEPART (YEAR,@Fecha) AND
DATEPART (DAYOFYEAR,Fecha_Krdx)= DATEPART (DAYOFYEAR,@Fecha)
Go


select * from detalle_Kardex 
where Id_krdx ='KRD-0000002'
order by item asc
go


--eliminar karde
Create procedure sp_eliminar_Kardex
@idkardex char (20)
As
DElete from Detalle_Kardex where Id_krdx =@idkardex 
delete from KardexProducto where Id_krdx =@idkardex 
go



--Consultas de Productos que en la Fecha de hoy se quedaron sin SAldo:
--==== SON CONSULTAS NETAMENTE PARA CONOCER LOS REPORTES DEL SISTEMA===

create Proc Sp_Productos_sinSTock_DespuesdeVenta  --ESTE SP: se usa, cuando se quiere saber, cuales son los productos que no se vendieron a falta de stock:
@Fechadia date
As
Select * from V_Kardex_Detalle
Where
DATEPART (YEAR,Fecha_Krdx)= DATEPART (YEAR,@Fechadia) AND
DATEPART (DAYOFYEAR,Fecha_Krdx)= DATEPART (DAYOFYEAR,@Fechadia) and
Cantidad_Saldo =0 
order by Descripcion_Larga Asc
Go


--Para el Reporte por el Tipo de Operacion:
create Proc Sp_Productoskardex_porTipoOpera_fecha (
@desde date,
@hasta date,
@tipoOpera varchar (17)
)
As
Select * from V_Kardex_Detalle
Where
Fecha_Krdx between @desde and @hasta and
Tipo_operacion=@tipoOpera 
order by Fecha_Krdx Asc
Go








