use BDSISTEMA_BOTICA
go 



--insert de cierre de caja
Create Proc Reg_Cierre_Caja
(
@idCierre char (10),
@Apertura_Caja real,
@Total_Ingreso real,
@TotalEgreso real,
@Id_usu int,
@TodoDeposito real,
@TotalGanancia Real,
@TotalEntregado Real,
@SaldoSiguiente Real,
@TotalFactura Real,
@TotalBoleta Real,
@Totalnota Real,
@TotalCreditoCobrado real,
@TotalCreditoEmitido real
)
As
Insert Into  Cierre_Caja
Values 
(
@idCierre,
GETDATE(),
@Apertura_Caja ,
@Total_Ingreso ,
@TotalEgreso,
@Id_usu,
@TodoDeposito ,
@TotalGanancia ,
@TotalEntregado,
@SaldoSiguiente,
@TotalFactura,
@TotalBoleta,
@Totalnota ,
@TotalCreditoCobrado,
@TotalCreditoEmitido,
'Abierto'
)
Go

create procedure sp_Actualizar_Cierre_Caja (
@IDCIERRE char (10),
@Apertura_Caja real,
@Total_Ingreso real,
@TotalEgreso real,
@Id_usu int,
@TodoDeposito real,
@TotalGanancia Real,
@TotalEntregado Real,
@SaldoSiguiente Real,
@TotalFactura Real,
@TotalBoleta Real,
@Totalnota Real,
@TotalCreditoCobrado real,
@TotalCreditoEmitido real
)
AS
update Cierre_Caja set
Apertura_Caja =@Apertura_Caja ,
Total_Ingreso =@Total_Ingreso ,
TotalEgreso = @TotalEgreso ,
Id_Usu=@Id_usu,
TodoDeposito =@TodoDeposito ,
Gananciadeldia =@TotalGanancia ,
TotalEntregado =@TotalEntregado ,
SaldoSiguiente =@SaldoSiguiente ,
TotalFactura =@TotalFactura,
TotalBoleta =@TotalBoleta,
TotalNotaVenta =@Totalnota ,
TotalCreditoCobrado =@TotalCreditoCobrado ,
TotalCreditoEmitido =@TotalCreditoEmitido ,
Estado_cierre ='Cerrado'
where
Id_cierre =@IDCIERRE 
go

--vista:
create View v_cierreCaja_usu
as
select c.Id_cierre,c.Fecha_Cierre , c.Apertura_Caja , c.Total_Ingreso,
c.TotalEgreso , c.TodoDeposito, c.Estado_cierre ,C.Gananciadeldia ,C.TotalEntregado, C.SaldoSiguiente,C.TotalFactura,
C.TotalBoleta, C.TotalNotaVenta, C.TotalCreditoCobrado,C.TotalCreditoEmitido,
u.Id_Usu , u.Nombres , u.Apellidos , u.Nombres + ' ' + u.Apellidos as fullname
from Cierre_Caja c, Usuarios u
where
c.Id_Usu = u.Id_Usu 
go

--todos:
create Proc Sp_Cargar_todos_cierresCaja 
As
Select * from v_cierreCaja_usu
Where
Estado_cierre='Cerrado'
order by Fecha_Cierre Asc
GO

--1
create Proc Sp_Cargar_CierreCaja_delDia (
@xdia date,
@estadocierre varchar (17)
)
As
Select * from v_cierreCaja_usu
Where
Estado_cierre = @estadocierre  
AND CAST(Fecha_Cierre AS DATE) = @xdia 
GO


Create Proc Sp_Cargar_CierreCaja_delMes (
@xmes date
)
As
Select * from v_cierreCaja_usu
Where
DATEPART (YEAR ,Fecha_Cierre )= DATEPART (YEAR,@xmes) and
DATEPART (MONTH ,Fecha_Cierre )= DATEPART (MONTH,@xmes) 
GO


--Ver Cierres de Caja por Uusuario y Dia:
Create Proc Sp_Cargar_CierreCaja_porUsuario (
@Id_Usu int
)
As
Select * from v_cierreCaja_usu
Where
Id_Usu=@Id_Usu
order by Fecha_Cierre asc
GO


Create Proc Sp_Cargar_CierreCaja_porUsu_Mes (
@Id_Usu int,
@fechames date
)
As
Select * from v_cierreCaja_usu
Where
Id_Usu=@Id_Usu and
DATEPART (YEAR ,Fecha_Cierre )= DATEPART (YEAR,@fechames) and
DATEPART (Month ,Fecha_Cierre )= DATEPART (Month,@fechames) 
order by Fecha_Cierre asc
GO

--nuevo:13/03
Create Proc Sp_Cargar_CierreCaja_porRangoFecha (
@desde date,
@hasta date
)
As
Select * from v_cierreCaja_usu
Where
Fecha_Cierre between @desde and @hasta
order by Fecha_Cierre asc
GO



create Proc Sp_Cargar_CierreCaja_porId (
@idcierre char (10)
)
As
Select * from v_cierreCaja_usu
Where
Id_cierre=@idcierre
GO

--- validar registro de caja
create procedure SP_VALIDAR_REGISTRO_CAJA
AS
SELECT COUNT (*) FROM Cierre_Caja  
WHERE
DATEPART (YEAR ,Fecha_Cierre )= DATEPART (YEAR,GETDATE()) and
DATEPART (DAYOFYEAR ,Fecha_Cierre )= DATEPART (DAYOFYEAR,GETDATE()) and
Estado_cierre ='Abierto'
GO


--====================== PROCESOS PARA EMPEZAR A SUMAR LAS VENTAS SEGUN SUS TIPOS
--1 Uno
create Procedure Sp_Calcular_Ventas_PorTipoDoc
@tipodoc varchar (15)

As
Select * from Caja
Where
TipoPago ='Efectivo' and
GeneradoPor=@tipodoc and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
ModoCierre='Abierto' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
Go



--2) Ahora las Salidas
create Procedure Sp_Calcular_Gastos_porTipoPago
@tipopago varchar (12)
As
Select * from Caja
Where
TipoPago =@tipopago 	and
Tipo_caja = 'Salida' and
EstadoCaja ='Activo' And
ModoCierre='Abierto' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
Go


--3)
create Procedure Sp_Calcular_Ventas_aCredito
As
Select * from Caja
Where
TipoPago ='Credito'	and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
ModoCierre='Abierto' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
Go

--4)Ahroa todos lso depositso
create Procedure Sp_Calcular_Ventas_aDeposito
As
Select * from Caja
Where
TipoPago ='Tarjeta'	and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
ModoCierre='Abierto' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
Go



--5)Ahora listamos la Utilidad
Create Procedure Sp_Calcular_Ventas_GananciadelDia
As
Select * from Caja
Where
Tipo_caja = 'Entrada' and 
EstadoCaja ='Activo' And
ModoCierre='Abierto' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
Go

select * from Cierre_Caja
go