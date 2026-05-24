use BDSISTEMA_BOTICA
go 

--Validar no ingresar doble Cliente :
create procedure sp_Validar_NroDNI (
@dni char (18)
)
as
select COUNT(*) from Cliente 
where
DNI =@dni
go


--insert:
Create Procedure Sp_Registrar_Cliente (
@idcliente char (10),
@razonsocial varchar (250),
@dni char (18),
@direccion varchar (150),
@telefono char (10),
@email varchar (150),
@fechaAniver date
)
As
Insert into Cliente values
(
@idcliente ,
@razonsocial ,
@dni ,
@direccion ,
@telefono,
@email ,
@fechaAniver ,
'Activo'
)
go


--update:
Create Procedure Sp_Modificar_Cliente (
@idcliente char (10),
@razonsocial varchar (250),
@dni char (18),
@direccion varchar (150),
@telefono char (10),
@email varchar (150),
@idDis int,
@fechaAniver date
)
As
update cliente set
Razon_Social_Nombres = @razonsocial ,
DNI=@dni ,
Direccion=@direccion ,
Telefono=@telefono ,
E_Mail=@email ,
Fcha_Ncmnto_Anivsrio=@fechaAniver 
where
Id_Cliente =@idcliente 
go



--alter View V_Clientes_Distritos
--As
--Select Id_Cliente,Razon_Social_Nombres,DNI ,
--Direccion,telefono, e_mail,Cliente.Id_Dis,Distrito, Fcha_Ncmnto_Anivsrio ,Contacto,Limit_Credit,Estado_cli
--From  Cliente
--	INNER JOIN Distrito  On Cliente.Id_Dis = Distrito .Id_Dis 
--Where 
--	Cliente.Estado_cli ='Activo'
--Go

--Listamos todos los clientes:
Create Procedure sp_Listar_Todos_Clientes (
@estado varchar (12)
)
As
IF @estado ='Todos'
    Select * from Cliente 
	order by Razon_Social_Nombres Asc
ELSE 
    Select * from Cliente 
	where
	Estado_Cli =@estado 
	order by Razon_Social_Nombres Asc
go

exec sp_Listar_Todos_Clientes 'Activo'
go

--Buscamos por Nombre:
Create Procedure Sp_Buscar_Cliente_porValor (
@Valor varchar (250)
)
As
Select * from Cliente 
where
DNI =@Valor or
Id_Cliente =@Valor or
Razon_Social_Nombres like '%' + @Valor + '%' 
go

--Eliminar:
Create Procedure Sp_DarBajar_Cliente (
@idcliente char (10),
@estado varchar (15)
)
As
Update Cliente set
Estado_Cli =@estado 
where
Id_Cliente =@idcliente 
go

Create Procedure Sp_Eliminar_Cliente(
@idcliente char (10)
)
As
Delete from Cliente 
where
Id_Cliente =@idcliente 
go




