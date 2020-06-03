CREATE TABLE [dbo].[TipoVisita] (
    [idTipoVisita] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]       NVARCHAR (50) NOT NULL,
    [activo]       BIT           NULL,
    CONSTRAINT [PK_TipoVisita] PRIMARY KEY CLUSTERED ([idTipoVisita] ASC)
);

