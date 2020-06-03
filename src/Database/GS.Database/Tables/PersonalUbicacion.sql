CREATE TABLE [dbo].[PersonalUbicacion] (
    [idPersonal]    INT      IDENTITY (1, 1) NOT NULL,
    [idUbicacion]   INT      NOT NULL,
    [fechaRegistro] DATETIME NOT NULL,
    [activo]        BIT      NULL,
    CONSTRAINT [FK_PersonalUbicacion_Personal] FOREIGN KEY ([idPersonal]) REFERENCES [dbo].[Personal] ([idPersonal]),
    CONSTRAINT [FK_PersonalUbicacion_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion])
);

