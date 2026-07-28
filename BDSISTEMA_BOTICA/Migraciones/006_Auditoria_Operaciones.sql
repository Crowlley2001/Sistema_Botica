USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.AuditoriaOperacion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AuditoriaOperacion
    (
        IdAuditoria BIGINT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_AuditoriaOperacion PRIMARY KEY,
        FechaHora DATETIME2(0) NOT NULL
            CONSTRAINT DF_AuditoriaOperacion_Fecha DEFAULT (SYSDATETIME()),
        IdUsuario INT NULL,
        Operacion VARCHAR(40) NOT NULL,
        Entidad VARCHAR(40) NOT NULL,
        Identificador VARCHAR(50) NULL,
        EstadoAnterior VARCHAR(30) NULL,
        EstadoNuevo VARCHAR(30) NULL,
        ImporteSoles DECIMAL(18,2) NULL,
        Detalle NVARCHAR(500) NULL,
        UsuarioSql SYSNAME NOT NULL
            CONSTRAINT DF_AuditoriaOperacion_UsuarioSql DEFAULT (ORIGINAL_LOGIN()),
        Equipo VARCHAR(128) NULL
            CONSTRAINT DF_AuditoriaOperacion_Equipo DEFAULT (HOST_NAME()),
        Aplicacion VARCHAR(128) NULL
            CONSTRAINT DF_AuditoriaOperacion_Aplicacion DEFAULT (APP_NAME())
    );

    CREATE INDEX IX_AuditoriaOperacion_Fecha
        ON dbo.AuditoriaOperacion (FechaHora DESC);

    CREATE INDEX IX_AuditoriaOperacion_EntidadIdentificador
        ON dbo.AuditoriaOperacion (Entidad, Identificador);
END;
GO

CREATE OR ALTER TRIGGER dbo.TR_Documento_Auditoria
ON dbo.Documento
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditoriaOperacion
    (
        IdUsuario, Operacion, Entidad, Identificador,
        EstadoAnterior, EstadoNuevo, ImporteSoles, Detalle
    )
    SELECT
        i.Id_Usu,
        CASE
            WHEN d.id_Doc IS NULL THEN 'EMISION_VENTA'
            WHEN ISNULL(d.Estado_Doc, '') <> ISNULL(i.Estado_Doc, '')
                THEN 'CAMBIO_ESTADO_VENTA'
            ELSE 'MODIFICACION_VENTA'
        END,
        'Documento',
        RTRIM(i.id_Doc),
        d.Estado_Doc,
        i.Estado_Doc,
        CONVERT(DECIMAL(18,2), i.ImporteDoc),
        CASE
            WHEN i.Estado_Doc = 'Anulado'
                THEN N'Comprobante anulado'
            ELSE N'Operación registrada automáticamente'
        END
    FROM inserted i
    LEFT JOIN deleted d ON d.id_Doc = i.id_Doc;
END;
GO

CREATE OR ALTER TRIGGER dbo.TR_DocumentoCompras_Auditoria
ON dbo.DocumentoCompras
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditoriaOperacion
    (
        IdUsuario, Operacion, Entidad, Identificador,
        EstadoAnterior, EstadoNuevo, ImporteSoles, Detalle
    )
    SELECT
        i.id_Usu,
        CASE
            WHEN d.Id_DocComp IS NULL THEN 'REGISTRO_COMPRA'
            WHEN ISNULL(d.Estado_Ingre, '') <> ISNULL(i.Estado_Ingre, '')
                THEN 'CAMBIO_ESTADO_COMPRA'
            ELSE 'MODIFICACION_COMPRA'
        END,
        'DocumentoCompras',
        RTRIM(i.Id_DocComp),
        d.Estado_Ingre,
        i.Estado_Ingre,
        CONVERT(
            DECIMAL(18,2),
            CASE
                WHEN COL_LENGTH(
                    'dbo.DocumentoCompras', 'TotalSoles') IS NOT NULL
                    THEN ISNULL(i.TotalSoles, i.Total_Ingre)
                ELSE i.Total_Ingre
            END),
        CONCAT(N'Comprobante proveedor: ', RTRIM(i.NroFac_Fisico))
    FROM inserted i
    LEFT JOIN deleted d ON d.Id_DocComp = i.Id_DocComp;
END;
GO

CREATE OR ALTER TRIGGER dbo.TR_Usuarios_Auditoria
ON dbo.Usuarios
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditoriaOperacion
    (
        IdUsuario, Operacion, Entidad, Identificador,
        EstadoAnterior, EstadoNuevo, Detalle
    )
    SELECT
        i.Id_Usu,
        CASE
            WHEN d.Id_Usu IS NULL THEN 'CREACION_USUARIO'
            WHEN ISNULL(d.Estado_Usu, '') <> ISNULL(i.Estado_Usu, '')
                THEN 'CAMBIO_ESTADO_USUARIO'
            ELSE 'MODIFICACION_USUARIO'
        END,
        'Usuarios',
        CONVERT(VARCHAR(20), i.Id_Usu),
        d.Estado_Usu,
        i.Estado_Usu,
        CONCAT(N'Usuario: ', i.Usuario)
    FROM inserted i
    LEFT JOIN deleted d ON d.Id_Usu = i.Id_Usu;
END;
GO

CREATE OR ALTER VIEW dbo.V_Auditoria_Operaciones
AS
    SELECT
        a.IdAuditoria,
        a.FechaHora,
        a.Operacion,
        a.Entidad,
        a.Identificador,
        a.EstadoAnterior,
        a.EstadoNuevo,
        a.ImporteSoles,
        a.Detalle,
        a.IdUsuario,
        LTRIM(RTRIM(CONCAT(ISNULL(u.Nombres, ''), ' ', ISNULL(u.Apellidos, ''))))
            AS NombreUsuario,
        a.Equipo,
        a.Aplicacion
    FROM dbo.AuditoriaOperacion a
    LEFT JOIN dbo.Usuarios u ON u.Id_Usu = a.IdUsuario;
GO
