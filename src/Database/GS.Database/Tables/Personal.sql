CREATE TABLE [dbo].[Personal] (
    [idPersonal]   INT            IDENTITY (1, 1) NOT NULL,
    [nombre]       NVARCHAR (500) NOT NULL,
    [ApPaterno]    NVARCHAR (500) NOT NULL,
    [ApMaterno]    NVARCHAR (500) NULL,
    [activo]       BIT            NOT NULL,
    [fotoPersonal] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED ([idPersonal] ASC)
);

