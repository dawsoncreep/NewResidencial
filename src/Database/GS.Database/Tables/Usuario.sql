CREATE TABLE [dbo].[Usuario] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Nombres]     NVARCHAR (100) NOT NULL,
    [Apellidos]   VARCHAR (100)  NOT NULL,
    [Correo]     VARCHAR (100)  NOT NULL,
    [Telefono]    VARCHAR (20)   NULL,
    [Celular]    VARCHAR (20)   NULL,
    [Alias]    NVARCHAR (20)  NOT NULL,
    [Contraseña] NVARCHAR (256) NOT NULL,
    [Activo] BIT NOT NULL, 

    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

