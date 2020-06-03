CREATE TABLE [dbo].[Vehiculo] (
    [idVehiculo]  INT            IDENTITY (1, 1) NOT NULL,
    [descripcion] NVARCHAR (200) NOT NULL,
    [placas]      NVARCHAR (10)  NOT NULL,
    [activo]      BIT            NULL,
    [tag]         NVARCHAR (24)  NULL,
    CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED ([idVehiculo] ASC)
);

