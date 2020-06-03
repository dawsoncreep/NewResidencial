CREATE TABLE [dbo].[UsuarioRol] (
    [idUsuario] INT NOT NULL,
    [idRol]     INT NOT NULL,
    CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED ([idUsuario] ASC, [idRol] ASC),
    CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[Rol] ([idRol]),
    CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([Id])
);

