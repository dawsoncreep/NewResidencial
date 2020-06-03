CREATE TABLE [dbo].[IngresoSalidaVisita] (
    [idVisita]           INT            IDENTITY (1, 1) NOT NULL,
    [fechaIngreso]       DATETIME       NOT NULL,
    [fotoPlacaDelantera] NVARCHAR (200) NOT NULL,
    [fotoPlacaTrasera]   NVARCHAR (200) NOT NULL,
    [fotoCabina]         NVARCHAR (200) NOT NULL,
    [fotoIdentificacion] NVARCHAR (200) NULL,
    [fechaSalida]        DATETIME       NULL,
    [fotoSalidaUrl]      NVARCHAR (200) NULL,
    CONSTRAINT [FK_ingresoSalidaVisita_Visita] FOREIGN KEY ([idVisita]) REFERENCES [dbo].[Visita] ([idVisita])
);

