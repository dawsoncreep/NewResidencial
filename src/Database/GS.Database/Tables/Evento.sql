CREATE TABLE [dbo].[Evento] (
    [idEvento]    INT             IDENTITY (1, 1) NOT NULL,
    [nombre]      NVARCHAR (50)   NOT NULL,
    [incio]       DATETIME        NOT NULL,
    [fin]         DATETIME        NOT NULL,
    [QR]          NVARCHAR (1239) NOT NULL,
    [idUbicacion] INT             NOT NULL,
    [activo]      INT             NOT NULL,
    [idUsuario]   INT             NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([idEvento] ASC),
    CONSTRAINT [FK_Evento_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion]),
    CONSTRAINT [FK_UsuarioEvento] FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([Id])
);

