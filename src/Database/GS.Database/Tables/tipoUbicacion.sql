﻿CREATE TABLE [dbo].[TipoUbicacion] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]          NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tipoUbicacion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

