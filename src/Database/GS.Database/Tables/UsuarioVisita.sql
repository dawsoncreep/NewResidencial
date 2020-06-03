CREATE TABLE [dbo].[UsuarioVisita] (
    [idUsuario]     INT      NOT NULL,
    [idVisita]      INT      NOT NULL,
    [fechaRegistro] DATETIME NOT NULL,
    [activo]        BIT      NOT NULL,
    CONSTRAINT [FK_UsuarioVisita_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([Id]),
    CONSTRAINT [FK_UsuarioVisita_Visita] FOREIGN KEY ([idVisita]) REFERENCES [dbo].[Visita] ([idVisita])
);

