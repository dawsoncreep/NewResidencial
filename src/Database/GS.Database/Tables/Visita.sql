CREATE TABLE [dbo].[Visita] (
    [idVisita]     INT             IDENTITY (1, 1) NOT NULL,
    [idTipoVisita] INT             NOT NULL,
    [nombre]       NVARCHAR (200)  NOT NULL,
    [apellidos]    NVARCHAR (200)  NOT NULL,
    [placas]       NVARCHAR (10)   NULL,
    [fotoUrl]      NVARCHAR (200)  NULL,
    [idUbicacion]  INT             NOT NULL,
    [activo]       BIT             NULL,
    [QR]           NVARCHAR (1239) NULL,
    CONSTRAINT [PK_Visita] PRIMARY KEY CLUSTERED ([idVisita] ASC),
    FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion]),
    CONSTRAINT [FK_Visita_TipoVisita] FOREIGN KEY ([idTipoVisita]) REFERENCES [dbo].[TipoVisita] ([idTipoVisita])
);

