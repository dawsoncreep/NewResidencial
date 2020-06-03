CREATE TABLE [dbo].[Rol] (
    [idRol]  INT           IDENTITY (1, 1) NOT NULL,
    [nombre] NVARCHAR (50) NOT NULL,
    [activo] BIT           NULL,
    CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ([idRol] ASC)
);

