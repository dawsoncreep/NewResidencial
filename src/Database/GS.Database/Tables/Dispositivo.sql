CREATE TABLE [dbo].[Dispositivo] (
    [idDispositivo]   INT           IDENTITY (1, 1) NOT NULL,
    [Ip]              NVARCHAR (50) NOT NULL,
    [usuario]         NVARCHAR (50) NULL,
    [password]        NVARCHAR (50) NULL,
    [idUbicacion]     INT           NOT NULL,
    [activo]          BIT           NOT NULL,
    [puerto]          NVARCHAR (20) NULL,
    [tipoDispositivo] NVARCHAR (50) NULL,
    [protocolo]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_Dispositivo] PRIMARY KEY CLUSTERED ([idDispositivo] ASC),
    CONSTRAINT [FK_Dispositivo_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion])
);

