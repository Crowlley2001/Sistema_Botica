use BDSISTEMA_BOTICA
go

--Ahora los Procedimientos Almacenados:
create proc Sp_Registrar_Temporal_ReportKardex (
  @idprod char (20),
  @NombreProducto varchar (150),
  @stock real,
  @preCompra real,
  @Comp_x_Stock real,
  @PreVenta real,
  @Venta_x_Stock real,
  @Utilidad real,
  @Utili_x_Stock real,
  @obs varchar (50)
)
As
Insert into Temporal_ReportKardex values (
  @idprod,
  @NombreProducto,
  @stock,
  @preCompra,
  @Comp_x_Stock,
  @PreVenta,
  @Venta_x_Stock,
  @Utilidad,
  @Utili_x_Stock,
  @obs
)
Go

--borrar el temporal:
Create proc sp_Eliminar_Temporal_Kardex
As
Delete from Temporal_ReportKardex
go

Create proc sp_Listar_Temporal_Kardex
As
Select * from v_Kardex_Vista
go


Create view v_Kardex_Vista
As
Select
    t.idprod ,
    t.NombreProducto ,
    t.stock ,
    t.preCompra ,
    t.Comp_x_Stock ,
    t.PreVenta ,
    t.Venta_x_Stock ,
    t.Utilidad ,
    t.Utili_x_Stock ,
    t.obs
from Temporal_ReportKardex t
go
