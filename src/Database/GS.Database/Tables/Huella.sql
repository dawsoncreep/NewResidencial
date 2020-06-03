CREATE TABLE [dbo].[Huella] (
    [idHuella]      INT              IDENTITY (1, 1) NOT NULL,
    [huella]        VARBINARY (1632) NOT NULL,
    [activo]        BIT              NOT NULL,
    [fechaRegistro] DATETIME         NOT NULL,
    [idPersonal]    INT              NOT NULL,
    CONSTRAINT [PK_Huella] PRIMARY KEY CLUSTERED ([idHuella] ASC),
    CONSTRAINT [FK_HuellaPersonal] FOREIGN KEY ([idPersonal]) REFERENCES [dbo].[Personal] ([idPersonal])
);

