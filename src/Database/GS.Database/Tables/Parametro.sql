CREATE TABLE [dbo].[Parametro] (
    [name]        NVARCHAR (50)   NOT NULL,
    [valor]       NVARCHAR (200)  NOT NULL,
    [descripcion] NVARCHAR (2000) NULL,
    [metadata]    NVARCHAR (2000) NULL,
    [activo]      BIT             NULL,
    CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED ([name] ASC)
);

