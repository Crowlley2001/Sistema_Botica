use BDSISTEMA_BOTICA
go 


--insert:
create Procedure sp_registrar_Caja (

@Fecha_Caja datetime,
@Tipo_Caja varchar (50),
@Concepto varchar (190),
@De_Para varchar (180),
@Nro_Doc char (20),
@ImporteCaja real,
@Id_Usu int,
@TotalUti real,
@TipoPago varchar (13),
@GeneradoPor varchar (15),
@totaldescuento real
)
As
Insert into Caja Values (
@Fecha_Caja ,
@Tipo_Caja ,
@Concepto ,
@De_Para ,
@Nro_Doc ,
@ImporteCaja ,
@Id_Usu,
@TotalUti ,
@TipoPago ,
@GeneradoPor ,
'Activo',
@totaldescuento,
'Abierto'  --cuando se hace el Cierre de Caja, se pondrá en Cerrado, asi sabremos que movimientos, Falta, cerrar en el 2do Turno:

)
Go

--acutalizar importe caja
create procedure Sp_Actualizar_Total_Caja
@Nro_doc char (11),
@total Real,
@TotalUtilidad real,
@TipoPago varchar (12)
As
update caja set
ImporteCaja =@total ,
TotalUti =@TotalUtilidad 
where 
Nro_Doc =@Nro_doc and
TipoPago =@TipoPago 
go


create View V_Caja_Usuario
As
Select 
Cj.Idcaja , Cj.Fecha_Caja , Cj.Tipo_Caja , Cj.Concepto , Cj.De_Para , Cj.Nro_Doc  , Cj.ImporteCaja , Cj.TipoPago ,
Cj.TotalUti,cj.EstadoCaja ,Cj.GeneradoPor,Cj.Total_Dscuentos, Cj.Modocierre,
Ui.Id_Usu , Ui.Nombres , Ui.Apellidos 
 from Caja Cj, Usuarios Ui
Where
cj.Id_Usu = Ui.Id_Usu 
Go

/* CONSULTAS PARA EL EXPLORADOR DE CAJA Y OTRAS VENTANAS */
/* ======================================================*/
create Procedure Sp_Listar_Todas_Cajas
	As
	Select * from V_Caja_Usuario
	order by Fecha_Caja ASc
Go

--Cajas del dia
---------select mostrar caja-----
create PROC Sp_Listar_Cajas_delDia
@dia DATE
AS
SELECT * 
FROM V_Caja_Usuario
WHERE
EstadoCaja = 'Activo'
AND ModoCierre = 'Abierto'
AND CAST(Fecha_Caja AS DATE) = @dia
ORDER BY Nro_Doc ASC
GO

--delmes
Create  Procedure  Sp_Listar_Cajas_del_Mes
@fechas date
as
select * from V_Caja_Usuario
where
DATEPART (YEAR ,Fecha_Caja)= DATEPART (YEAR,@fechas) AND
DATEPART (MONTH ,Fecha_Caja)= DATEPART (MONTH,@fechas)
order by Fecha_Caja ASc
go

--rangos:
create  Procedure  Sp_Listar_Cajas_porFechas
@desde date,
@hasta date
as
select * from V_Caja_Usuario
where
Fecha_Caja between @desde and @hasta
Order By Nro_Doc Asc
go


Create  Procedure  Sp_Listar_Cajas_porMes_tipoDoc
@fechas date,
@tipodoc varchar (15)
as
select * from V_Caja_Usuario
where
DATEPART (YEAR ,Fecha_Caja)= DATEPART (YEAR,@fechas) AND
DATEPART (MONTH ,Fecha_Caja)= DATEPART (MONTH,@fechas) and
GeneradoPor=@tipodoc 
order by Fecha_Caja ASc
go

--Buscar movimiento de Caja por Cliente
create procedure Sp_Buscador_MoviCaja_xValor
@xvalor varchar (150)
As
Select * from V_Caja_Usuario
Where
Nro_Doc=@xvalor or
TipoPago=@xvalor or
Tipo_caja=@xvalor or
Nombres=@xvalor or
GeneradoPor=@xvalor or
De_Para like + '%'+ @xvalor  or De_Para  like + '%' + @xvalor  + '%' or
De_Para like @xvalor  + '%' 
Order by Fecha_Caja Asc
Go


--anular:
create proc sp_Anular_movCaja (
@NroDoc char (11),
@estadoCaja varchar (20)
)
As
 update Caja set
 EstadoCaja=@estadoCaja
 where
 Nro_Doc=@NroDoc 
 go


create PROC sp_cambiarModo_cierreCaja
@idcaja INT
AS
UPDATE Caja 
SET 
    ModoCierre = 'Cerrado',
    EstadoCaja = 'Cerrado'
WHERE Idcaja = @idcaja

 create  Procedure  Sp_Listar_gastos_deldia_paraReporte(
@dia date
)
as
select * from V_Caja_Usuario
where
EstadoCaja='Activo'and
DATEPART (YEAR ,Fecha_Caja)= DATEPART (YEAR,@dia) AND
DATEPART (DAYOFYEAR ,Fecha_Caja)= DATEPART (DAYOFYEAR,@dia)
go

