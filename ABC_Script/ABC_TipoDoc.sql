use BDSISTEMA_BOTICA
go

--insert:
INSERT INTO Tipo_Doc values (1, 'Factura','FE01','000001','Activo')
INSERT INTO Tipo_Doc values (2, 'Boleta','BE01','000001','Activo')
INSERT INTO Tipo_Doc values (3, 'Nota Venta','NV01','000001','Activo')
INSERT INTO Tipo_Doc values (4, 'Cotizacion','CTZ','000001','Activo')
go

------update tipo_doc
Create proc Sp_Editar_Tipo_Doc
(
@idtipo int,
@documento varchar(50),
@serie varchar(4),
@numero varchar (6)
)
as
if not exists (select * from Tipo_Doc where Id_Tipo = @idtipo)
begin
print 'El Municipio no existe'
return
end
begin tran
update tipo_doc set 
Documento  = @documento ,
Serie = @serie ,
Numero = @numero   
where Id_Tipo = @idtipo    
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
go

--especial para tipo de documento
create proc SP_Listar_Tipo_Doc
as
select * from Tipo_Doc 
where Estado_tiDoc='Activo'
go

--nuevo:
--especial para tipo de documento
create proc SP_Listar_Tipo_Doc_porId (
@idtipo int
)
as
select * from Tipo_Doc 
where
Estado_tiDoc='Activo' and
Id_Tipo = @idtipo 
go

create Proc Sp_Tipod_Doc_Spcial
As
Select * from Tipo_Doc 
Where Id_Tipo = '3' or Id_Tipo ='2' or Id_Tipo ='1'
order by Documento Desc
Go


--Para los Correlativos:
Create Procedure Sp_Listado_Tipo
	@Id_Tipo as Int	
AS
	Select Serie + '-' + Numero as Nro from Tipo_Doc 
	Where Id_Tipo=@Id_Tipo
Go

exec Sp_Listado_Tipo 2;
go

----=============================================================
---- FUNCION QUE GENERA CODIGO DE DOCUMENTOS
----=============================================================
create FUNCTION Auto_Genera_Doc(@Id_Tipo int)
Returns Char(6)
Begin 
	Declare @Nro as varchar(6)
	Select @Nro=RIGHT('000000' + convert(varchar,Cast(Numero AS INT)+1),6)  From Tipo_Doc  
	Where Id_Tipo=@Id_tipo
	
	Return(@Nro)
End
Go

select * from tipo_doc
go



------=============================================================
------ ACTUALIZA NUMERO CORRELATIVO DE DOCUMENTOS
------=============================================================
create Procedure Sp_Actualiza_Tipo_Doc(
@Id_Tipo int
)
As

IF NOT EXISTS(SELECT * FROM TIPO_DOC
		WHERE Id_Tipo =@Id_Tipo)
	BEGIN		
		RETURN
	END

Begin
	Declare @NuevoNum char(6)
	Set @NuevoNum = dbo.Auto_Genera_Doc(@Id_Tipo)
End
BEGIN TRANSACTION

UPDATE TIPO_DOC SET	
	Numero = @NuevoNum
WHERE 
	Id_Tipo=@Id_Tipo
	
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
Go

--Editar:
create proc Sp_Editar_Tipo_Cambio
(
@idtipo int,
@numero nvarchar (6)
)
as
update tipo_doc set 
Numero = @numero   
where Id_Tipo = @idtipo   
go


--lectura del tipo de cambio:
--Para los Correlativos:
Create Procedure Sp_Listar_TipoCambio
	@Id_Tipo as Int	
AS
	Select Numero from Tipo_Doc 
	Where Id_Tipo=@Id_Tipo
Go

exec Sp_Listar_TipoCambio 7
go