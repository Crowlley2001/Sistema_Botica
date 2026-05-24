use BDSISTEMA_BOTICA
go


--insert:
create Procedure Sp_Registrar_Pedido(
@id_Ped char (11),
@Id_Cliente char (10),
--fecha
@SubTotal real,
@IgvPed real,
@TotalPed real,
@id_Usu int,
@TotalGancia real,
@totaldscuento real
)
As
Insert into Pedido values
(
@id_Ped ,
@Id_Cliente ,
getdate(),
@SubTotal ,
@IgvPed ,
@TotalPed ,
@id_Usu ,
@TotalGancia,
@totaldscuento,
'Pendiente'
)
Go

--detalle:
create procedure sp_Registrar_detalle_Pedido(
@id_Ped char (11),
@Id_Pro char (20),
@Precio real,
@Cantidad real,
@Importe real,
@Utilidad_Unit real,
@TotalUtilidad real,
@descuentoDet real

)
as
insert into Detalle_Pedido values
(
@id_Ped ,
@Id_Pro ,
@Precio ,
@Cantidad,
@Importe ,
@Utilidad_Unit ,
@TotalUtilidad ,
@descuentoDet
)
go


--borrar Detalle:
Create procedure sp_eliminar_detalle_Pedido (
@id_Ped char (11)
)
As
Delete from Detalle_Pedido where
id_Ped =@id_Ped 
go


--update:
create Procedure [dbo].[Sp_Editar_Pedido](
@id_Ped char (11),
@Id_Cliente char (10),
@SubTotal real,
@IgvPed real,
@TotalPed real,
@id_Usu int,
@TotalGancia real,
@totaldscuento real
)
As
update Pedido set
Id_Cliente =@Id_Cliente ,
SubTotal =@SubTotal ,
IgvPed=@IgvPed,
TotalPed =@TotalPed ,
TotalGancia =@TotalGancia ,
Total_Dscuento=@totaldscuento
where
id_Ped =@id_Ped 
go


Create Procedure Sp_Verificar_Id_Pedido
@Id_Ped char (11)
As
Select COUNT (*) from Pedido 
Where id_Ped = @Id_Ped 
Go

--cambiar Estado:
create Procedure Sp_Pedido_Atendido(
	@Id_Ped Nvarchar(11)
)
As
	UPDATE Pedido  SET
	Estado_Ped  ='Atendido'
	WHERE Id_Ped=@Id_Ped
GO


--Cambiar solo el Cliente:
Create Procedure Sp_Actu_clien_Ped(
	@Id_Ped char (11),
	@Id_cli char(10)
	
)
As
	UPDATE Pedido SET
		Id_Cliente =@Id_cli 
	WHERE Id_Ped=@Id_Ped
GO

--Eliminar Todo el Pedido:
Create Procedure Sp_Eliminar_Pedido_Completo(
	@Id_Ped char(11)
)
As
Delete from Detalle_Pedido WHERE Id_Ped=@Id_Ped
Delete from Pedido WHERE Id_Ped=@Id_Ped
GO

--consultas:
create View V_Listado_Pedido_Detalle
As
	Select Ped.Id_Ped,Cli.id_cliente,Cli.Razon_Social_Nombres,
		ped.Total_Dscuento,		
		Cli.DNI ,Cli.Direccion,Cli.Telefono, Cli.E_mail,
		Ped.SubTotal,Ped.Fecha_Ped,Ped.TotalPed, ped.Estado_Ped ,ped.TotalGancia ,
		Ped.id_Usu,
		Det.Precio, Det.Cantidad, Det.Importe ,det.DescuentoDet,Det.Utilidad_Unit ,Det.TotalUtilidad,
		
		Pro.Descripcion_Larga, Pro.Id_Pro ,Pro.Stock_Actual     
	From Pedido Ped, Detalle_Pedido Det, Productos Pro, Cliente Cli 
	where 
	Det.Id_Ped =Ped.Id_Ped And
	Ped.id_cliente=Cli.id_cliente And
	Det.Id_Pro=Pro.Id_Pro
Go

--Buscar pedido completo con detalle:
Create  Procedure Sp_Buscar_Pedido_Para_Editar (
@Id_Ped char(11)
)
As
	Select * from V_Listado_Pedido_Detalle
	Where Id_Ped = @Id_Ped
Go

--PEdidos para el Explorador:
Create view V_Pedidos_Cliente_General
					as
					select P.id_Ped , P.SubTotal , P.TotalPed  , P.Fecha_Ped , p.Estado_Ped ,P.TotalGancia , P.Total_Dscuento,
							C.Id_Cliente , C.Razon_Social_Nombres , C.DNI,C.Estado_Cli , 
							u.Id_Usu , u.Nombres 
							from Pedido P,Cliente C,Usuarios U
					Where
							p.Id_Cliente = c.Id_Cliente  and
							p.id_Usu = u.Id_Usu 
Go

--todos:




--Buscadir de Pedidos:
Create Procedure Sp_buscar_Pedidos_porValor(
@valor varchar(250)
)
As
	Select  * from V_Pedidos_Cliente_General
	Where
	Razon_Social_Nombres like @valor + '%' or
	Razon_Social_Nombres like '%' + @valor or
	id_Ped=@valor or
	Id_Cliente=@valor or
	DNI=@valor 	
	Order by Fecha_Ped  desc
Go

--pedidos por Fecha:
Create Procedure Sp_Listar_Pedidos_porFecha (
@tipo varchar (20),
@fecha date
)
as
if @tipo ='dia'
	Select * from V_Pedidos_Cliente_General
	where
	DATEPART (YEAR ,Fecha_Ped)= DATEPART (YEAR,@fecha)  and
	DATEPART (DAYOFYEAR ,Fecha_Ped)= DATEPART (DAYOFYEAR,@fecha) 
	order by Fecha_Ped Asc
else
Select * from V_Pedidos_Cliente_General
	where
	DATEPART (YEAR ,Fecha_Ped)= DATEPART (YEAR,@fecha)  and
	DATEPART (MONTH ,Fecha_Ped)= DATEPART (MONTH,@fecha) 
	order by Fecha_Ped Asc
Go


--Ver Pedidos PEndiente de atencion:
create Procedure Sp_Leer_Pedidos_PorAtender
as
select * from V_Pedidos_Cliente_General
where 
Estado_Ped ='Pendiente' and
DATEPART (YEAR ,Fecha_Ped )= DATEPART (YEAR,GETDATE()) and
DATEPART (DAYOFYEAR ,Fecha_Ped )= DATEPART (DAYOFYEAR,GETDATE())
Go


--====================

create  Procedure Sp_cargar_productos_masVendidos (
@desde date,
@hasta date
)
As
	Select top 10 Id_Pro , COUNT (Id_Pro) as TotalProd , Descripcion_Larga , Cantidad  from V_Listado_Pedido_Detalle
	Where 
	Fecha_Ped between @desde and @hasta 
	group by Id_Pro , Descripcion_Larga, Cantidad 
	order by COUNT (2) desc
Go

exec Sp_cargar_productos_masVendidos '01-05-2021','30-05-2021'
go