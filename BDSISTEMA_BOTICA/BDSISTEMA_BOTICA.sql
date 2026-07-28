use master 
go

/**** Nombre de la Base de Datos ***/
create Database BDSISTEMA_BOTICA
go

USE [BDSISTEMA_BOTICA]
GO


CREATE TABLE [dbo].[Caja](
	[Idcaja] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Caja] [datetime] NULL,
	[Tipo_Caja] [varchar](50) NULL,
	[Concepto] [nvarchar](190) NULL,
	[De_Para] [varchar](180) NULL,
	[Nro_Doc] [char](20) NULL,
	[ImporteCaja] [real] NULL,
	[Id_Usu] [int] NULL,
	[TotalUti] [real] NULL,
	[TipoPago] [varchar](50) NULL,
	[GeneradoPor] [varchar](15) NULL,
	[EstadoCaja] [varchar](13) NULL,
	[Total_Dscuentos] [real] not null,
	[ModoCierre] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idcaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Categorias](
	[Id_Cat] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Cierre_Caja](
	[Id_cierre] [char](10) NOT NULL,
	[Fecha_Cierre] [datetime] NOT NULL,
	[Apertura_Caja] [real] NOT NULL,
	[Total_Ingreso] [real] NULL,
	[TotalEgreso] [real] NULL,
	[Id_Usu] [int] NULL,
	[TodoDeposito] [real] NULL,
	[Gananciadeldia] [real] NULL,
	[TotalEntregado] [real] NULL,
	[SaldoSiguiente] [real] NULL,
	[TotalFactura] [real] NULL,
	[TotalBoleta] [real] NULL,
	[TotalNotaVenta] [real] NULL,
	[TotalCreditoCobrado] [real] NULL,
	[TotalCreditoEmitido] [real] NULL,
	[Estado_cierre] [varchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_cierre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [char](10) NOT NULL,
	[Razon_Social_Nombres] [nvarchar](250) NULL,
	[DNI] [char](18) NOT NULL,
	[Direccion] [nvarchar](150) NULL,
	[Telefono] [char](10) NULL,
	[E_Mail] [nvarchar](150) NULL,	
	[Fcha_Ncmnto_Anivsrio] [datetime] NULL,	
	[Estado_Cli] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Cotizacion](
	[Id_Cotiza] [char](11) NOT NULL,
	[Id_Ped] [char](11) NOT NULL,
	[FechaCoti] [datetime] NULL,
	[Vigencia] [int] NULL,
	[TotalCotiza] [real] NULL,
	[Condiciones] [varchar](450) NULL,
	[PrecioconIgv] [char](4) NULL,
	[EstadoCoti] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cotiza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Credito](
	[IdNotaCred] [char](11) NOT NULL,
	[Id_Doc] [char](11) NOT NULL,
	[Fecha_Credito] [datetime] NOT NULL,
	[Nom_Cliente] [varchar](50) NULL,
	[Total_Cre] [real] NULL,
	[Saldo_Pdnte] [real] NULL,
	[Fecha_Vncimnto] [date] NULL,
	[Estado_Cred] [varchar](13) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNotaCred] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[DataRerport](
	[iddata] [int] IDENTITY(1,1) NOT NULL,
	[fecha1] [varchar](30) NULL,
	[fecha2] [varchar](30) NULL,
	[Usuario] [varchar](40) NULL,
	[TipoConsulta] [varchar](120) NULL,
PRIMARY KEY CLUSTERED 
(
	[iddata] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Detalle_Credito](
	[Id_DetCred] [int] IDENTITY(1,1) NOT NULL,
	[IdNotaCred] [char](11) NOT NULL,
	[A_cuenta] [real] NOT NULL,
	[Saldo_Actual] [real] NULL,
	[Fecha_Pago] [datetime] NULL,
	[TipoPago] [varchar](50) NULL,
	[Nro_Opera_Coment] [nvarchar](180) NULL,
	[Id_Usu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_DetCred] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Detalle_DocumCompra](
	[Id_DocComp] [char](11) NOT NULL,
	[Id_Pro] [char](20) NOT NULL,
	[PrecioUnit] [real] NULL,
	[Cantidad] [real] NULL,
	[Importe] [real] NULL,
	[preventa] [real] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Detalle_Kardex](
	[Id_krdx] [char](11) NOT NULL,
	[Item] [int] NOT NULL,
	[Fecha_Krdx] [datetime] NOT NULL,
	[Doc_Soporte] [nchar](20) NULL,
	[Det_Operacion] [varchar](180) NULL,
	[Cantidad_In] [real] NULL,
	[Precio_In] [real] NULL,
	[Total_In] [real] NULL,
	[Cantidad_Out] [real] NULL,
	[Precio_Out] [real] NULL,
	[Total_Out] [real] NULL,
	[Cantidad_Saldo] [real] NULL,
	[Promedio] [real] NULL,
	[Costo_Total_Saldo] [real] NULL,
	[Id_Usu] [int] NULL,
	[Tipo_operacion] [varchar](17) NULL,
	[Cant_Difncial] [varchar](10) NULL,
	[ImportDiferen] [real] NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Detalle_Pedido](
	[id_Ped] [char](11) NOT NULL,
	[Id_Pro] [char](20) NOT NULL,
	[Precio] [real] NULL,
	[Cantidad] [real] NULL,
	[Importe] [real] NULL,	
	[Utilidad_Unit] [real] NULL,
	[TotalUtilidad] [real] NULL,	
	[DescuentoDet] [real] ,
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Detalle_Temporal](
	[codTem] [nchar](12) NOT NULL,
	[CodPro] [char](11) NULL,
	[cantidad] [nchar](20) NULL,
	[Producto] [varchar](250) NULL,
	[Pre_Unt] [varchar](50) NULL,
	[ImporteT] [varchar](50) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Documento](
	[id_Doc] [char](11) NOT NULL,
	[id_Ped] [char](11) NOT NULL,
	[Id_Tipo] [int] NOT NULL,
	[Fecha_Emi] [datetime] NULL,
	[ImporteDoc] [real] NOT NULL,
	[TipoPago] [varchar](50) NULL,
	[Nro_Operacion] [nchar](20) NULL,
	[Id_Usu] [int] NOT NULL,	
	[TotalGanancia] [real] NULL,
	[TotalDscuento] [real],
	[Estado_Doc] [varchar](13) NULL

PRIMARY KEY CLUSTERED 
(
	[id_Doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DocumentoCompras](
	[Id_DocComp] [char](11) NOT NULL,
	[NroFac_Fisico] [char](20) NOT NULL,
	[SubTotal_ingre] [real] NULL,
	[Fecha_Ingre] [datetime] NULL,
	[Total_Ingre] [real] NOT NULL,
	[id_Usu] [int] NOT NULL,
	[ModalidadPago] [varchar](50) NOT NULL,
	[TiempoEspera] [int] NULL,
	[Fecha_Vencimiento] [datetime] NULL,
	[Estado_Ingre] [varchar](20) NULL,
	[Datos_Adicional] [nvarchar](150) NULL,
	[TipoDoc_Compra] [varchar](12) NOT NULL,
	[Tiporegistro] [varchar](15) NULL,
	[LugarSalida] [varchar](250) NULL,
	[TipoProceso] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_DocComp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[KardexProducto](
	[Id_krdx] [char](11) NOT NULL,
	[Id_Pro] [char](20) NOT NULL,
	[FechaCre] [date] NULL,
	[EstadoKrdx] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_krdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Marcas](
	[Id_Marca] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Menu_xUsu](
	[Id_menuxusu] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_menu] [varchar](50) NOT NULL,
	[Id_usu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_menuxusu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Miempresa](
	[idrancho] [int] NOT NULL,
	[nombreRancho] [varchar](250) NULL,
	[nroRuc] [char](20) NULL,
	[Direccionran] [varchar](250) NULL,
	[correo] [varchar](180) NULL,
	[clavecorreo] [varchar](20) NULL,
	[clavesol] [varchar](20) NULL,
	[usuariosol] [varchar](20) NULL,
	[clavecertificado] [varchar](20) NULL,
	[obs] [varchar](240) NULL,
PRIMARY KEY CLUSTERED 
(
	[idrancho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Pedido](
	[id_Ped] [char](11) NOT NULL,
	[Id_Cliente] [char](10) NOT NULL,
	[Fecha_Ped] [datetime] NULL,
	[SubTotal] [real] NULL,
	[IgvPed] [real] NULL,
	[TotalPed] [real] NULL,
	[id_Usu] [int] NOT NULL,
	[TotalGancia] [real] NULL,	
	[Total_Dscuento] [real] NULL,
	[Estado_Ped] [varchar](12) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[id_Ped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

create TABLE [dbo].[Productos](
	[Id_Pro] [char](20) NOT NULL,
	[Descripcion_Larga] [nvarchar](150) NOT NULL,	
	[Pre_CompraS] [real] NOT NULL,
	[Stock_Actual] [real] NOT NULL,
	[Id_Cat] [int] NOT NULL,
	[Foto] [varchar](180) NULL,
	[Pre_venta] [real] NOT NULL,	
	[Frmto_Compra] [varchar](10) NULL,
	[UtilidadUnit] [real] NULL,
	[Valor_porCant] [real] NULL,
	[Estado_Pro] [varchar](15) NULL,
	[Prin_Acti] [varchar](20) NULL,
	[Laboratorio] [varchar](20) NULL,
	[Und_Min] [int] NULL,
	[Und_Max] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaVncmnto] [varchar](11) NULL,
	[VentaConReceta] [varchar](20) NULL,
	[comisionporcen] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductosSinValor](
	[idPrCon] [int] IDENTITY(1,1) NOT NULL,
	[Id_Pro] [char](20) NOT NULL,
	[Id_Usu] [int] NOT NULL,
	[FecharegProd] [datetime] NULL,
	[MotivoIngre] [varchar](15) NULL,  --//no tuvo estock para la venta
PRIMARY KEY CLUSTERED 
(
	[idPrCon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--01 junio - 1500.00
--02 junio  - 500.0

--total = 1700.00



CREATE TABLE [dbo].[ReporteTotalizado](
	[idTotal] [int] IDENTITY(1,1) NOT NULL,
	[FechaVenta] [varchar](120) NULL,
	[TotalVenta] [real] NULL,
	[totalGastos] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[idTotal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Roles](
	[Id_Rol] [int] NOT NULL,
	[Rol] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Temporal](
	[CodTem] [nchar](12) NOT NULL,
	[FechaEmi] [varchar](20) NULL,
	[cliente] [varchar](150) NULL,
	[Ruc] [varchar](50) NULL,
	[Direccion] [varchar](150) NULL,
	[SubTtal] [varchar](50) NULL,
	[IgvT] [varchar](50) NULL,
	[TotalT] [varchar](50) NULL,
	[TotalDscto] [varchar] (50) not null,
	[SonT] [varchar](200) NULL,
	[Vendedor] [varchar](120) NULL,
	[CodigoQr] [varbinary](max) NULL,
	[Tipocomprobante] [varchar](50) NULL,
	[HashCpe] [varchar](60) NULL,
	[MotivoEmi] [varchar](60) NULL,
	[TipoPago] [varchar](50) NULL,
	[DireccionTienda] [varchar](220) NULL,
	[NombreSucursal] [varchar](220) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodTem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Temporal_ReportKardex](
	[idprod] [char](20) NOT NULL,
	[NombreProducto] [varchar](150) NULL,
	[stock] [real] NULL,
	[preCompra] [real] NULL,
	[Comp_x_Stock] [real] NULL,
	[PreVenta] [real] NULL,
	[Venta_x_Stock] [real] NULL,
	[Utilidad] [real] NULL,
	[Utili_x_Stock] [real] NULL,
	[obs] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idprod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tipo_Doc](
	[Id_Tipo] [int] NOT NULL,
	[Documento] [nvarchar](50) NULL,
	[Serie] [varchar](4) NULL,
	[Numero] [nvarchar](6) NULL,
	[Estado_TiDoc] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuarios](
	[Id_Usu] [int] NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,	
	[Usuario] [varchar](8) NOT NULL,
	[Contraseña] [varchar](10) NOT NULL,
	[FotoUsu] [varchar](200) NULL,
	[Fecha_Ncmiento] [datetime] NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[Correo] [varchar](150) NULL,
	[Estado_Usu] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ValeCompra](
	[IdVale] [char](11) NOT NULL,
	[Id_Cliente] [char](10) NOT NULL,
	[NroDoc] [char](11) NOT NULL,
	[ImporteVale] [real] NULL,
	[DetalleVale] [varchar](220) NOT NULL,
	[EstadoVale] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*** AHORA VAMOS A RELACIONAR LAS TABLAS ***/
ALTER TABLE [dbo].[Caja]  WITH CHECK ADD  CONSTRAINT [FK_caja_usu] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Caja] CHECK CONSTRAINT [FK_caja_usu]
GO

ALTER TABLE [dbo].[Cierre_Caja]  WITH CHECK ADD  CONSTRAINT [FK_cirre_usu] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Cierre_Caja] CHECK CONSTRAINT [FK_cirre_usu]
GO


ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_coti_cli] FOREIGN KEY([Id_Ped])
REFERENCES [dbo].[Pedido] ([id_Ped])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_coti_cli]
GO


ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_cre_doc] FOREIGN KEY([Id_Doc])
REFERENCES [dbo].[Documento] ([id_Doc])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_cre_doc]
GO


ALTER TABLE [dbo].[Detalle_Credito]  WITH CHECK ADD  CONSTRAINT [FK_cred_usudet] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Detalle_Credito] CHECK CONSTRAINT [FK_cred_usudet]
GO

ALTER TABLE [dbo].[Detalle_Credito]  WITH CHECK ADD  CONSTRAINT [FK_cred_Det] FOREIGN KEY([IdNotaCred])
REFERENCES [dbo].[Credito] ([IdNotaCred])
GO
ALTER TABLE [dbo].[Detalle_Credito] CHECK CONSTRAINT [FK_cred_Det]
GO


ALTER TABLE [dbo].[Detalle_DocumCompra]  WITH CHECK ADD  CONSTRAINT [FK_detcom] FOREIGN KEY([Id_DocComp])
REFERENCES [dbo].[DocumentoCompras] ([Id_DocComp])
GO
ALTER TABLE [dbo].[Detalle_DocumCompra] CHECK CONSTRAINT [FK_detcom]
GO


ALTER TABLE [dbo].[Detalle_DocumCompra]  WITH CHECK ADD  CONSTRAINT [FK_detcom_prod] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[Detalle_DocumCompra] CHECK CONSTRAINT [FK_detcom_prod]
GO


ALTER TABLE [dbo].[Detalle_Kardex]  WITH CHECK ADD  CONSTRAINT [FK_detkar_usu] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Detalle_Kardex] CHECK CONSTRAINT [FK_detkar_usu]
GO


ALTER TABLE [dbo].[Detalle_Kardex]  WITH CHECK ADD  CONSTRAINT [FK_Kar_det] FOREIGN KEY([Id_krdx])
REFERENCES [dbo].[KardexProducto] ([Id_krdx])
GO
ALTER TABLE [dbo].[Detalle_Kardex] CHECK CONSTRAINT [FK_Kar_det]
GO


ALTER TABLE [dbo].[Detalle_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_det_ped] FOREIGN KEY([id_Ped])
REFERENCES [dbo].[Pedido] ([id_Ped])
GO
ALTER TABLE [dbo].[Detalle_Pedido] CHECK CONSTRAINT [FK_det_ped]
GO


ALTER TABLE [dbo].[Detalle_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_det_Prd] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[Detalle_Pedido] CHECK CONSTRAINT [FK_det_Prd]
GO


ALTER TABLE [dbo].[Detalle_Temporal]  WITH CHECK ADD  CONSTRAINT [FK_tem_Det] FOREIGN KEY([codTem])
REFERENCES [dbo].[Temporal] ([CodTem])
GO
ALTER TABLE [dbo].[Detalle_Temporal] CHECK CONSTRAINT [FK_tem_Det]
GO


ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_doc_ped] FOREIGN KEY([id_Ped])
REFERENCES [dbo].[Pedido] ([id_Ped])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_doc_ped]
GO


ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_doc_tip] FOREIGN KEY([Id_Tipo])
REFERENCES [dbo].[Tipo_Doc] ([Id_Tipo])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_doc_tip]
GO


ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_doc_usux] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_doc_usux]
GO


ALTER TABLE [dbo].[DocumentoCompras]  WITH CHECK ADD  CONSTRAINT [FK_com_usu] FOREIGN KEY([id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[DocumentoCompras] CHECK CONSTRAINT [FK_com_usu]
GO

ALTER TABLE [dbo].[KardexProducto]  WITH CHECK ADD  CONSTRAINT [FK_Kar_Prod] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[KardexProducto] CHECK CONSTRAINT [FK_Kar_Prod]
GO

ALTER TABLE [dbo].[Menu_xUsu]  WITH CHECK ADD  CONSTRAINT [FK_mnu_usu] FOREIGN KEY([Id_usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Menu_xUsu] CHECK CONSTRAINT [FK_mnu_usu]
GO

ALTER TABLE [dbo].[Menu_xUsu]  WITH CHECK ADD  CONSTRAINT [FK_mnuusu] FOREIGN KEY([Id_usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Menu_xUsu] CHECK CONSTRAINT [FK_mnuusu]
GO


ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Ped_cli] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Ped_cli]
GO

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Ped_usu] FOREIGN KEY([id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Ped_usu]
GO


ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Prod_Cat] FOREIGN KEY([Id_Cat])
REFERENCES [dbo].[Categorias] ([Id_Cat])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Prod_Cat]
GO

ALTER TABLE [dbo].[ProductosSinValor]  WITH CHECK ADD  CONSTRAINT [FK_pro_cons] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[ProductosSinValor] CHECK CONSTRAINT [FK_pro_cons]
GO

ALTER TABLE [dbo].[ProductosSinValor]  WITH CHECK ADD  CONSTRAINT [FK_prodcon_usu] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios] ([Id_Usu])
GO
ALTER TABLE [dbo].[ProductosSinValor] CHECK CONSTRAINT [FK_prodcon_usu]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_rol_usu] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Roles] ([Id_Rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_rol_usu]
GO


ALTER TABLE [dbo].[ValeCompra]  WITH CHECK ADD  CONSTRAINT [FK_val_cli] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[ValeCompra] CHECK CONSTRAINT [FK_val_cli]
GO
