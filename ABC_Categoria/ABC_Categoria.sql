use BDBoticaCurso
go 


--insert:
Create Procedure SP_Registrar_Categoria (
@nombrecateg varchar (50)
)
As
Insert into Categorias values (@nombrecateg )
go


--Update_:
Create Procedure SP_Editar_Categoria (
@idCat int,
@nombrecateg varchar (50)
)
As
update Categorias set
[Categoria]=@nombrecateg
where
Id_Cat=@idCat
go


--consulta:
Create Proc sp_Listar_Todas_Categ
as
Select * from Categorias 
order by Categoria asc
go
