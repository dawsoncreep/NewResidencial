CREATE TABLE [dbo].[FotoEventoSalida] (
    [idFotoEventoSalida] INT            IDENTITY (1, 1) NOT NULL,
    [idEvento]           INT            NOT NULL,
    [placa]              NCHAR (10)     NULL,
    [fotoSalida]         NVARCHAR (200) NULL,
    CONSTRAINT [FK_FotoEventoSalida_Evento] FOREIGN KEY ([idEvento]) REFERENCES [dbo].[Evento] ([idEvento])
);

