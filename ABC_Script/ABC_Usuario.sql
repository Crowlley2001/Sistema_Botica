use BDSISTEMA_BOTICA
go
select * from Usuarios
insert into Usuarios values (1, 'Erwin','Rodriguez', 'admin','admin','-','08/03/1988',1,'-','Activo')
go

--1================= MODIFICACIONES: 02/05/
Create View V_Usuarios_Roles
As
Select Id_Usu,u.Nombres , u.Apellidos , u.Nombres + ' ' + u.Apellidos as FullName,   u.Usuario ,u.Contraseña ,FotoUsu,
U.Id_Rol,R.Rol  ,U.Estado_usu,  u.Correo , u.Fecha_Ncmiento 
From Usuarios U, Roles R
Where U.Id_Rol=R.Id_Rol
Go
                


create Procedure Sp_LeerUsuario_Login(
	@Usuario varchar(50)=''
)
As
	Select * from V_Usuarios_Roles
	Where
	Usuario=@Usuario and Estado_usu = 'Activo'
Go

Execute Sp_Usuario_Login 'admin'
go



--login
Create Procedure Sp_Login
@Usuario nvarchar(20),
@Contraseña nvarchar(12)
As
	Select Count(*)from Usuarios 
	Where Usuario =@Usuario and Contraseña =@Contraseña
Go


--usuarios:
create proc sp_registrar_Usuario (
@idusu int,
@nombres varchar (50),
@apellidos varchar (50),
@usu varchar (8),
@clave varchar (10),
@foto varchar (200),
@fechaNaci date,
@idrol int,
@correo varchar (150)
)
As
Insert into Usuarios 
values (

@idusu ,
@nombres,
@apellidos,
@usu ,
@clave ,
@foto ,
@fechaNaci ,
@idrol ,
@correo ,
'Activo'
)
Go


--todos:  Aqui tambien cambiar 
create proc sp_listar_Todos_users
as
select * from V_Usuarios_Roles
go


create PROC sp_eliminar_Usu
(
@idusu int
)
AS
UPDATE Usuarios
SET Estado_Usu = 'Eliminado'
WHERE Id_Usu = @idusu
GO

create proc sp_editar_Usuario (
@idusu int,
@nombres varchar (50),
@apellidos varchar (50),
@usu varchar (8),
@clave varchar (10),
@foto varchar (200),
@fechaNaci date,
@idrol int,
@correo varchar (150)
)
As
Update Usuarios 
set
Nombres=@nombres,
Apellidos=@apellidos ,
Usuario=@usu ,
Contraseña=@clave ,
FotoUsu=@foto ,
Fecha_Ncmiento=@fechaNaci ,
Id_Rol=@idrol ,
Correo=@correo
where
Id_Usu=@idusu
Go

create Procedure Sp_Buscar_Usuario(
	@idusu int
)
As
	Select * from V_Usuarios_Roles
	Where
	Id_Usu=@idusu
Go


create proc Sp_Cargar_todos_Roles
as
select * from Roles
order by Rol asc
go