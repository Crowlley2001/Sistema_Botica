USE BDBoticaCurso 
Go




--Insert:
create procedure [dbo].[Sp_Registrar_Compra](
@idCom char (11),
@Nro_Fac_Fisico char (20),
@SubTotal_Com real,
@FechaIngre datetime,
@TotalCompra real,
@IdUsu int,
@ModalidadPago varchar (50),
@TiempoEspera int,
@FechaVence date,
@EstadoIngre varchar (20),
@Datos_Adicional varchar (150),
@Tipo_Doc_Compra varchar (12),
@Tiporegistro varchar (15),
@LugarSalida varchar (250),
@TipoProceso varchar (15)
)
as
insert into DocumentoCompras values (
@idCom,
@Nro_Fac_Fisico ,
@SubTotal_Com ,
@FechaIngre ,
@TotalCompra ,
@IdUsu ,
@ModalidadPago ,
@TiempoEspera ,
@FechaVence ,
@EstadoIngre ,
@Datos_Adicional ,
@Tipo_Doc_Compra ,
@Tiporegistro,
@LugarSalida,
@TipoProceso
)
Go

--Detalle:

create Procedure Sp_Insert_Detalle_ingreso
	@Id_ingreso char(11),
	@Id_Pro char(20),
	@Precio real,	
	@Cantidad real,
	@Importe real,
	@preventa real
As
INSERT INTO Detalle_DocumCompra
VALUES
(
	@Id_ingreso ,
	@Id_Pro,
	@Precio,
	@Cantidad,
	@Importe,
	@preventa
)	
Go

--Vista: Actualizar esto:

create View [dbo].[V_Documentos_Compra_Detalle]
As
	Select 
	c.Id_DocComp , c.NroFac_Fisico ,c.SubTotal_ingre , c.Fecha_Ingre , c.Total_Ingre , c.ModalidadPago, c.TiempoEspera , c.Fecha_Vencimiento ,
	c.Estado_Ingre , c.Datos_Adicional , c.TipoDoc_Compra ,	C.Tiporegistro,C.LugarSalida,C.TipoProceso,
	Det.PrecioUnit , Det.Cantidad, Det.Importe,Det.preventa,
	Pro.Id_Pro, Pro.Descripcion_Larga, pro.Stock_Actual, pro.Pre_CompraS ,
	u.Id_Usu, u.Nombres, u.Apellidos, u.Nombres + '' + u.Apellidos as fullname
	From
	DocumentoCompras c, Detalle_DocumCompra Det, Productos Pro, Usuarios u
	where	
	c.Id_DocComp =Det.Id_DocComp  And
	Det.Id_Pro=Pro.Id_Pro and
	c.id_Usu = u.Id_Usu
GO

--Buscar un Documento de Compra Completo:
Create Proc Sp_Buscar_FacturasCompras_Detalle
@xvalor nchar (20)
As
Select * from V_Documentos_Compra_Detalle
Where
Id_DocComp=@xvalor or
NroFac_Fisico=@xvalor
Go

exec Sp_Buscar_FacturasCompras_Detalle 'CMP-0000008'
go



--Una Vista solo de las Tablas Principales o Master:
--Actualizar esto Tambien:

create View [dbo].[V_Documentos_CompraPrincipal]
As
	Select 
	c.Id_DocComp , c.NroFac_Fisico ,c.SubTotal_ingre , c.Fecha_Ingre , c.Total_Ingre , c.ModalidadPago, c.TiempoEspera , c.Fecha_Vencimiento ,
	c.Estado_Ingre  , c.Datos_Adicional , c.TipoDoc_Compra , C.Tiporegistro,C.LugarSalida,	C.TipoProceso,
	u.Id_Usu , u.Nombres , u.Apellidos , u.Usuario	   
	From
	DocumentoCompras c, Usuarios u
	where
	c.id_Usu = u.Id_Usu 
GO

     
--Consultas para el Explorador de Compras:
--1) Ahora un Buscador General
create Procedure Sp_Buscador_Gnral_deCompras
@xvalor varchar (150)
As
Select * from V_Documentos_CompraPrincipal
Where
Id_DocComp=@xvalor or
NroFac_Fisico = @xvalor or
TipoDoc_Compra=@xvalor 
Go

--================================================

--1:
Create Procedure [dbo].[Sp_Leer_Todas_Facturas_Compras]
As
Select * from V_Documentos_CompraPrincipal
go

--facturas ingreadas en el dia
create Procedure Sp_Facturas_Ingresadas_alDia (
@tipo varchar (20),
@fecha date
)
As
if @tipo ='dia'
	Select * from V_Documentos_CompraPrincipal
	where
	DATEPART (YEAR ,Fecha_Ingre)= DATEPART (YEAR,@fecha)  and
	DATEPART (DAYOFYEAR ,Fecha_Ingre)= DATEPART (DAYOFYEAR,@fecha) 
	order by Fecha_Ingre Asc
else
Select * from V_Documentos_CompraPrincipal
	where
	DATEPART (YEAR ,Fecha_Ingre)= DATEPART (YEAR,@fecha)  and
	DATEPART (MONTH ,Fecha_Ingre)= DATEPART (MONTH,@fecha) 
	order by Fecha_Ingre Asc
Go

exec Sp_Facturas_Ingresadas_alDia 'Mes','01/01/2020'
go

--Actualmente utilizando para eliminar la factura
Create Procedure SP_Borrar_Factura_Ingresada
@Id_Fac char (11)
As
Delete from Detalle_DocumCompra
where Id_DocComp =@Id_Fac 
Delete from DocumentoCompras
where Id_DocComp =@Id_Fac 
Go

--
create procedure sp_validar_NroFisico_Compra (
@Nro_Doc_fisico char  (20)
)
as
select COUNT(*) from DocumentoCompras 
where
NroFac_Fisico =@Nro_Doc_fisico 
go

