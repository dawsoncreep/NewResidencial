CREATE TABLE [dbo].[Boletin] (
    [idBoletin]     INT            IDENTITY (1, 1) NOT NULL,
    [mensaje]       NVARCHAR (500) NOT NULL,
    [activo]        BIT            NULL,
    [fechaRegistro] DATETIME       NOT NULL,
    [idUsuario]     INT            NULL,
    [fechaFin]      DATETIME       NULL,
    CONSTRAINT [PK_Boletin] PRIMARY KEY CLUSTERED ([idBoletin] ASC)
);

