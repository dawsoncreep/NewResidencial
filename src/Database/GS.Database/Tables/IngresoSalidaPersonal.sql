CREATE TABLE [dbo].[IngresoSalidaPersonal] (
    [idPersonal]   INT            IDENTITY (1, 1) NOT NULL,
    [fechaIngreso] DATETIME       NULL,
    [fechaSalida]  DATETIME       NULL,
    [fotoEntrada]  NVARCHAR (200) NULL,
    [fotoSalida]   NVARCHAR (200) NULL,
    CONSTRAINT [FK_IngresoSalidaPersonal_Personal] FOREIGN KEY ([idPersonal]) REFERENCES [dbo].[Personal] ([idPersonal])
);

