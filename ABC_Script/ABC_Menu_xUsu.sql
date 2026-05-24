use BDSISTEMA_BOTICA
GO

create procedure [dbo].[sp_registrar_MenuxUsuario]
(
    @nombremenu varchar(180),
    @idusu int
)
AS
BEGIN

INSERT INTO Menu_xUsu
(
    Nombre_menu,
    Id_Usu
)
VALUES
(
    @nombremenu,
    @idusu
)
END

--Eliminar:
Create proc sp_eliminarMenu_xId (
    @idUsu int
)
As
Delete from Menu_xUsu
where
    Id_Usu=@idUsu
go



create proc sp_Listar_menu_porIdUsu (
    @idusu int
)
As
Select * from Menu_xUsu where
    [Id_usu]=@idusu
go


Create proc sp_Verificar_siUsu_tieneMenu (
    @idUsu int
)
As
Select COUNT(*) from Menu_xUsu
where
    Id_usu = @idUsu
go

Create procedure [dbo].[sp_cargar_menu_xcod] (
    @nommenu varchar (180),
    @idUsu int
)
As
select Id_menuxusu from Menu_xUsu
where
    Nombre_menu = @nommenu and
    Id_usu = @idUsu
Go
