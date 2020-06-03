CREATE TABLE [dbo].[VehiculoUbicacion] (
    [idVehiculo]    INT      NOT NULL,
    [idUbicacion]   INT      NOT NULL,
    [activo]        BIT      NULL,
    [fechaRegistro] DATETIME NULL,
    CONSTRAINT [PK_VehiculoUbicacion] PRIMARY KEY CLUSTERED ([idVehiculo] ASC, [idUbicacion] ASC),
    CONSTRAINT [FK_VehiculoUbicacion_Ubicacion] FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[Ubicacion] ([idUbicacion]),
    CONSTRAINT [FK_VehiculoUbicacion_Vehiculo] FOREIGN KEY ([idVehiculo]) REFERENCES [dbo].[Vehiculo] ([idVehiculo])
);

