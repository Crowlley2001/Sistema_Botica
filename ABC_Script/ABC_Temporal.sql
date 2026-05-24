
use BDSISTEMA_BOTICA
go

create Proc Sp_Insertar_Temporal
(
@codTem Nchar (12),
@FechaEmi varchar (20),
@cliente varchar (150),
@Ruc varchar (20),
@Direccion varchar (150),
@SubTtal varchar (10),
@IgvT varchar (10),
@TotalT varchar (10),
@TotalDscto varchar (50),
@SonT varchar (200),
@vendedor varchar (120),
@CodigoQr varchar (300),
@Tipocomprobante varchar (50),
@HashCpe varchar (60),
@MotivoEmi varchar (60),
@TipoPago varchar (20)
)
As
BEGIN
    -- SEGURIDAD: Limpiamos las tablas temporales por completo.
    -- Esto evita el error de PRIMARY KEY DUPLICATE y mezcla de productos.
    DELETE FROM Detalle_Temporal;
    DELETE FROM Temporal;

    -- Insertamos el registro nuevo sin riesgo de choque
    Insert Into Temporal Values
    (
    @codTem,
    @FechaEmi,
    @cliente,
    @Ruc ,
    @Direccion ,
    @SubTtal ,
    @IgvT ,
    @TotalT,
    @TotalDscto,
    @SonT,
    @vendedor,
    @CodigoQr,
    @Tipocomprobante ,
    @HashCpe ,
    @MotivoEmi ,
    @TipoPago ,
    '-',
    '-'
    )
END
GO

--detalle
create Proc Sp_registrar_Det_Temporal
(
@Codtem Nchar (12),
@CodProd char (11),
@Cantidad nchar (20),
@Producto varchar (250),
@PreUnt Varchar (50),
@Importe Varchar (50)
)
As
BEGIN
    Insert Into dbo.Detalle_Temporal
    Values (
    @Codtem ,
    @CodProd,
    @Cantidad ,
    @Producto,
    @PreUnt ,
    @Importe 
    )
END
GO



CREATE VIEW V_Temporales_Detalle
AS
SELECT 
    T.CodTem,
    T.FechaEmi,
    T.Cliente,
    T.Ruc,
    T.Direccion,
    T.SubTtal,
    T.IgvT,
    T.TotalT,
    T.SonT,
    T.Vendedor,
    'F:\PORTAFOLIO\SISTEMA_BOTICA\CPE_2\QR_TEMP\' 
        + LTRIM(RTRIM(T.CodTem)) + '.BMP' AS CodigoQr,
    T.Tipocomprobante,
    T.HashCpe,
    T.MotivoEmi,
    T.TipoPago,
    D.CodPro,
    D.Producto,
    D.Pre_Unt,
    D.ImporteT,
    D.Cantidad
FROM Temporal T
INNER JOIN Detalle_Temporal D 
    ON D.CodTem = T.CodTem
WHERE 
    LTRIM(RTRIM(T.CodTem)) <> ''
    AND LTRIM(RTRIM(D.CodPro)) <> '';
GO


SELECT *
FROM V_Temporales_Detalle
WHERE CodTem = 'NV01-000179'








--hacemos un sp por el codigo
Create Proc Sp_Listar_Temporales
@id nchar (12)
As
Select * from V_Temporales_Detalle
where CodTem= @id 
Go

exec Sp_Listar_Temporales 'NV0-0000016 '
go

Create Proc sp_Eliminar_Temporales
@idtempo char (12)
As
delete from Detalle_Temporal where CodTem=@idtempo
delete from Temporal where CodTem=@idtempo
go





Create Procedure Sp_Delete_Det_Temporal
@Id nchar (12)
As
Delete from detalle_Temporal
Where codTem =@Id 
Delete from Temporal 
Where CodTem =@Id 

Go




--validar archivo existente del temporal
Create Proc Sp_Validar_Archivos_Temporales
@Id_tem nchar (12)
AS
select COUNT (*) from Temporal 
where CodTem =@Id_tem 
Go

--Ahora una Limpieza General
Create Proc Sp_Limpiar_Temporales_Venta
As
Delete from detalle_Temporal
Delete from Temporal 
Go

--select * from Temporal 
--go

--select * from Detalle_Temporal 
--go
select * from Credito

select * from Caja
go