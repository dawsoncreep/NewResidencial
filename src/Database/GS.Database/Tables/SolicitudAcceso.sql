CREATE TABLE [dbo].[SolicitudAcceso] (
    [idVisita]               INT      NOT NULL,
    [idUbicacion]            INT      NULL,
    [idUsuarioConcedeAcceso] INT      NULL,
    [idUsuarioCancelaAcceso] INT      NULL,
    [fechaRespuesta]         DATETIME NULL,
    CONSTRAINT [FK_SolicitudAcceso_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion]),
    CONSTRAINT [FK_SolicitudAcceso_Visita] FOREIGN KEY ([idVisita]) REFERENCES [dbo].[Visita] ([idVisita])
);

