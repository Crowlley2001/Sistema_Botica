USE [$(BaseDatos)];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID('dbo.CpeEnvio', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.CpeEnvio
    (
        IdCpe BIGINT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_CpeEnvio PRIMARY KEY,
        IdDocumento CHAR(11) NOT NULL,
        Ambiente VARCHAR(20) NOT NULL,
        EstadoCpe VARCHAR(30) NOT NULL,
        CodigoRespuesta VARCHAR(20) NULL,
        MensajeRespuesta NVARCHAR(500) NULL,
        HashCpe VARCHAR(88) NULL,
        XmlGenerado NVARCHAR(MAX) NULL,
        CdrContenido NVARCHAR(MAX) NULL,
        FechaProceso DATETIME2(0) NOT NULL,
        Intentos INT NOT NULL
            CONSTRAINT DF_CpeEnvio_Intentos DEFAULT (0),
        CONSTRAINT UQ_CpeEnvio_Documento UNIQUE (IdDocumento),
        CONSTRAINT FK_CpeEnvio_Documento FOREIGN KEY (IdDocumento)
            REFERENCES dbo.Documento(id_Doc)
    );

    CREATE INDEX IX_CpeEnvio_EstadoFecha
        ON dbo.CpeEnvio(EstadoCpe, FechaProceso DESC);
END;
GO
