use BDSISTEMA_BOTICA
go


--validar codigo de comprobante
create Procedure Sp_Validar_Id_Doc 
@Id_Doc char (11)
As
Select COUNT (*) from Documento 
Where id_Doc =@Id_Doc 
Go
----=============================================================
---- STORE PROCEDURE AGREGAR DOCUMENTO DE VENTA
----=============================================================
create Procedure [dbo].[Sp_Insert_Documento](
	@id_Doc char(11),	
	@id_Ped char(11),	
	@Id_Tipo int,
	@Fecha_Emi datetime,
	@Importe real,
	@TipoPago varchar (50),
	@NroOpera nchar (20),	
	@id_Usu int,
	@TotalGanancia real,	
	@TotalDscuento real	
)
As
INSERT INTO DOCUMENTO
VALUES(
@id_Doc,
@id_Ped,
@Id_Tipo, 
@Fecha_Emi, 
@Importe, 
@TipoPago , 
@NroOpera ,
@id_Usu,
@TotalGanancia ,
@TotalDscuento,
'Activo'
)
GO

--Actualizar Totales del Documento:
Create Procedure Sp_Actualizar_documento(
	@Id_Doc Nvarchar(11),
	@importe Real,
	@TotalGanancia Real,
	@totaldscto real
)
As
	UPDATE Documento SET
	ImporteDoc =@importe ,
	TotalGanancia =@TotalGanancia ,
	TotalDscuento=@totaldscto 
	WHERE
	Id_Doc=@Id_Doc
go

--Vista Genral de Todo Documento
create View V_Listado_Documento
As
Select Doc.Id_Doc, doc.TipoPago , doc.ImporteDoc,doc.Fecha_Emi, doc.Estado_doc  ,Doc.Nro_Operacion ,
 Ped.id_Ped,Cli.id_cliente,Cli.Razon_Social_Nombres , Doc.TotalGanancia, Doc.TotalDscuento ,
Cli.DNI ,Cli.Direccion,
Ped.Fecha_Ped,Ped.SubTotal,Ped.TotalPed,Ped.Estado_Ped , Ped.IgvPed,	
t.Id_Tipo , t.Documento ,U.Id_Usu , U.Nombres , U.Apellidos, U.Nombres +' '+ U.Apellidos as NombreCompletoUsu	          
From
Documento Doc, Pedido Ped,Cliente Cli , Tipo_Doc t, Usuarios U
where 
Doc.id_Ped  = Ped.id_Ped And
Ped.id_cliente=Cli.id_cliente and
doc.Id_Tipo = t.Id_Tipo and
Ped.id_Usu = u.Id_Usu 	
Go


create procedure sp_listar_todos_Docs
As
select * from V_Listado_Documento
order by Fecha_Emi Asc
go


--2
Create Procedure Sp_Buscador_Documentos_xValor
@Xvalor varchar (250)
As
Select * from V_Listado_Documento
where
id_Doc =  @Xvalor or
TipoPago = @xvalor or
Documento = @xvalor or
id_Ped = @Xvalor or
Nombres = @Xvalor  or
Id_Cliente=@Xvalor or
DNI like @Xvalor or 
Estado_Doc=@Xvalor or
Razon_Social_Nombres like @Xvalor + '%' or Razon_Social_Nombres + '%' like  @Xvalor + '%' 
order by Fecha_Emi Asc
Go


Create Procedure Sp_Listar_Doc_emitoshoy
@FechaActual date
as
	Select * from V_Listado_Documento 
	Where 
	DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @FechaActual)AND
	DATEPART (DAYOFYEAR ,Fecha_Emi )= DATEPART (DAYOFYEAR,@FechaActual)
	order by id_Doc Asc
Go

exec Sp_Listar_Doc_emitoshoy '02-05-2021'
go


create Procedure Sp_Leer_Fcturas_Emtidas_EnunMes
@Fecha_Mes Date
	As
	Select * from V_Listado_Documento 
where 
DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @Fecha_Mes )AND
DATEPART (MONTH ,Fecha_Emi ) =DATEPART (MONTH,@Fecha_Mes )
ORDER BY Fecha_Emi ASC
GO

create PROCEDURE Sp_Leer_Comprobantes_Emtidas_EnunMes
    @Fecha_Mes DATE,
    @Docu INT
AS
BEGIN
    -- Calculamos el primer día del mes y el último día del mes
    DECLARE @InicioMes DATE = DATEFROMPARTS(YEAR(@Fecha_Mes), MONTH(@Fecha_Mes), 1);
    DECLARE @FinMes DATE = EOMONTH(@Fecha_Mes);

    SELECT * FROM V_Listado_Documento 
    WHERE Fecha_Emi >= @InicioMes 
      AND Fecha_Emi <= @FinMes 
      AND Id_Tipo = @Docu
    ORDER BY Fecha_Emi ASC
END
GO




--Buscar documentos en un rango de fecha

create Procedure Sp_Leer_Fcturas_Emtidas_enRangoFecha
@Fecha_Mes1 Date,
@Fecha_Mes2 Date
As
Select * from V_Listado_Documento 
where 
Fecha_Emi between @Fecha_Mes1 and @Fecha_Mes2
ORDER BY Fecha_Emi ASC
GO



--==== Ventas Generales. solo Activos:
--create Procedure Sp_Leer_FE_BE_NV_delMes
--@Fecha_Mes Date
--	As
--	Select * from V_Listado_Documento 
--where 
--DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @Fecha_Mes )AND
--DATEPART (MONTH ,Fecha_Emi ) =DATEPART (MONTH,@Fecha_Mes ) and
--Estado_Doc ='Activo'
--ORDER BY Fecha_Emi ASC
--GO

select * from tipo_Doc
go

--vista
create View V_Listado_Documento_Detalle
As
	Select Doc.Id_Doc,Ped.id_Ped,Cli.id_cliente,Cli.Razon_Social_Nombres,Cli.DNI ,Cli.Direccion,Doc.ImporteDoc ,		
		Ped.Fecha_Ped,Ped.SubTotal,Ped.TotalPed,
		Ped.id_Usu,Ped.Estado_Ped ,Ped.TotalGancia , 	
		Det.Precio, Det.Cantidad, Det.Importe,Det.Utilidad_Unit,Det.TotalUtilidad,
		det.DescuentoDet, 
		Pro.Id_Pro , Pro.Descripcion_Larga, Pro.Stock_Actual ,
		doc.TotalDscuento , doc.Estado_doc  ,doc.Fecha_Emi, doc.Nro_Operacion , doc.TipoPago , doc.totalganancia,
		tp.Id_Tipo , tp.Documento 
			          
	From	Documento Doc, Pedido Ped, Detalle_Pedido Det, Tipo_Doc Tp,
			Productos Pro, Cliente Cli 
	where 
	Doc.id_Ped  = Ped.id_Ped And
	Doc.Id_Tipo = Tp.Id_Tipo and
	Det.Id_Ped=Ped.Id_Ped And
	Ped.id_cliente=Cli.id_cliente And
	Det.Id_Pro=Pro.Id_Pro
GO

Create Proc Sp_Buscar_Documento_yDetalle (
@Nro_Doc nchar (11)
)
As
Select * from V_Listado_Documento_Detalle
where
Id_Doc=@Nro_Doc or
id_Ped =@Nro_Doc 
go

--Anular:
----=============================================================
Create Procedure Sp_Anular_Documento(
	@Id_Doc Nvarchar(11),
	@estado varchar (50)
)
As
BEGIN TRANSACTION
	UPDATE Documento SET
		Estado_doc =@estado
	WHERE Id_Doc=@Id_Doc
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO

--Cambiar:
Create Procedure Sp_Cambiar_TipoPago_Documento(
	@Id_Doc Nvarchar(11),
	@tipoPago varchar (50)
)
As
BEGIN TRANSACTION
	UPDATE Documento SET
		TipoPago  =@tipoPago 
	WHERE Id_Doc=@Id_Doc
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO

--cambiar estado de Nota:
--Cambiar:
Create Procedure Sp_Cambiar_EstadoCanjeado_Nota(
	@Id_Doc char(11)
)
As
BEGIN TRANSACTION
	UPDATE Documento SET
		Estado_Doc  ='Canjeado' 
	WHERE
	Id_Doc=@Id_Doc
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO

select * from Tipo_Doc 
go




--
Create Proc [dbo].[Sp_Leer_Docs_delDia_PorTipoDoc]
@Fecha_Mes Date,
@Docu Int
	As
	Select * from V_Listado_Documento 
where 
DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @Fecha_Mes )AND
DATEPART (DAYOFYEAR  ,Fecha_Emi ) =DATEPART (DAYOFYEAR ,@Fecha_Mes ) and
Id_Tipo=@Docu
ORDER BY id_Doc ASC
go



--Create Procedure Sp_Listar_Doc_emitoshoy_Totalizado
--@FechaActual date
--as
--	Select * from V_Listado_Documento 
--	Where 
--	Estado_Doc='Activo' and
--	DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @FechaActual)AND
--	DATEPART (DAYOFYEAR ,Fecha_Emi )= DATEPART (DAYOFYEAR,@FechaActual)

--Go



create PROCEDURE Sp_Eliminar_Documento
@id_Doc CHAR(11)
AS
DELETE FROM Documento
WHERE Id_Doc = @Id_Doc
GO







