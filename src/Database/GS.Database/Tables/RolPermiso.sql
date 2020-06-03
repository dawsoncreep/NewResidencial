CREATE TABLE [dbo].[RolPermiso] (
    [idRol]     INT NOT NULL,
    [idPermiso] INT NOT NULL,
    [activo]    BIT NOT NULL,
    CONSTRAINT [PK_RolPermiso] PRIMARY KEY CLUSTERED ([idRol] ASC, [idPermiso] ASC),
    CONSTRAINT [FK_RolPermiso_Permiso] FOREIGN KEY ([idPermiso]) REFERENCES [dbo].[Permiso] ([idPermiso]),
    CONSTRAINT [FK_RolPermiso_Rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[Rol] ([idRol])
);

