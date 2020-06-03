CREATE TABLE [dbo].[Ubicacion] (
    [idUbicacion]     INT           IDENTITY (1, 1) NOT NULL,
    [nombre]          NVARCHAR (50) NOT NULL,
    [idTipoUbicacion] INT           NOT NULL,
    [activo]          BIT           NOT NULL,
    CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED ([idUbicacion] ASC),
    CONSTRAINT [FK_Ubicacion_tipoUbicacion] FOREIGN KEY ([idTipoUbicacion]) REFERENCES [dbo].[TipoUbicacion] ([Id])
);