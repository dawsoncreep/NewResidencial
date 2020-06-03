CREATE TABLE [dbo].[UsuarioUbicacion] (
    [idUbicacion] INT NOT NULL,
    [idUsuario]   INT NOT NULL,
    CONSTRAINT [PK_UsuarioUbicacion] PRIMARY KEY CLUSTERED ([idUsuario] ASC, [idUbicacion] ASC),
    CONSTRAINT [FK_usuarioUbicacion_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion]),
    CONSTRAINT [FK_usuarioUbicacion_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([Id])
);

