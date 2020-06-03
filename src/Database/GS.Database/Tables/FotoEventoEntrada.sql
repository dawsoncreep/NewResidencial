CREATE TABLE [dbo].[FotoEventoEntrada] (
    [idFotoEvento]       INT            IDENTITY (1, 1) NOT NULL,
    [idEvento]           INT            NOT NULL,
    [fotoPlacaDelantera] NVARCHAR (200) NOT NULL,
    [fotoPlacaTrasera]   NVARCHAR (200) NULL,
    [fotoCabina]         NVARCHAR (200) NULL,
    [fotoIdentificacion] NVARCHAR (200) NULL,
    [fechaIngreso]       DATETIME       NOT NULL,
    [placa]              NCHAR (10)     NULL,
    CONSTRAINT [FK_FotoEvento_Evento] FOREIGN KEY ([idEvento]) REFERENCES [dbo].[Evento] ([idEvento])
);

