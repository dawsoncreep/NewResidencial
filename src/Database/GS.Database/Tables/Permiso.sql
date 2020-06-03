CREATE TABLE [dbo].[Permiso] (
    [idPermiso] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]    NVARCHAR (50) NOT NULL,
    [activo]    BIT           NOT NULL,
    CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED ([idPermiso] ASC)
);

