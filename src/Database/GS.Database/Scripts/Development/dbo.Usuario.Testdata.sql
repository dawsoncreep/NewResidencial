PRINT 'Loading Table #Usuario'
GO

CREATE TABLE #Usuario
(
	[Id]          INT            NULL,
    [Nombres]     NVARCHAR (100) NULL,
    [Apellidos]   VARCHAR (100)  NULL,
    [Correo]      VARCHAR (100)  NULL,
    [Telefono]    VARCHAR (20)   NULL ,
    [Celular]     VARCHAR (20)   NULL,
    [Alias]       NVARCHAR (20)  NULL,
    [Contraseña]  NVARCHAR (256) NULL,
    [Activo]      BIT            NULL 
)

-- Un super usuario
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (01, 'Guizzy', 'Seguridad', 'superadmin@guizzyseguridad.com', null, '+5215555555555', 'SuperAdmin', 'Password', 1)

-- Administrador de un condominio
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (02, 'Jaime', 'Castorena Tlatecali', 'jaime.castorena@psi.condominio.com', null , '+5214491114970', 'Jaime.Castorena', 'Password', 1)

-- Colonos de un departamento
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (03, 'Carlos', 'Avalos García', 'carlos.avalos@yahoo.com', null , '+5214773995559', 'Carlos.Avalos', 'Password', 1)
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (04, 'German', 'Avalos García', 'german.avalos@hotmail.com', null , '+5214777895912', 'German.Avalos', 'Password', 1)
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (05, 'Xavier', 'Hernández Reyes', 'xavier.hernandez@gmail.com', null , '+5215554986348', 'Xavier.Hernandez', 'Password', 1)

-- Guardias de caseta
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (06, 'Jose', 'Sanchez Martínez ', 'jose.sanchez@hotmail.com', null , '+5215578566484', 'Jose.Sanchez', 'Password', 1)
INSERT INTO #Usuario ([Id], [Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo]) VALUES (07, 'Oscar', 'Hernández Villegas', 'oscar.villegas@outlook.com', null , '+5215512364578', 'Oscar.Villegas', 'Password', 1)

MERGE dbo.Usuario as T
USING #Usuario as S
ON T.Id = S.Id
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([Nombres], [Apellidos], [Correo], [Telefono], [Celular], [Alias], [contraseña], [Activo])
    VALUES (S.[Nombres], S.[Apellidos], S.[Correo], S.[Telefono], S.[Celular], S.[Alias], S.[contraseña], S.[Activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.Nombres = S.Nombres,
	T.Apellidos = S.Apellidos,
    T.Correo = S.Correo,
    T.Telefono = S.Telefono,
    T.Celular = S.Celular,
    T.Alias = S.Alias,
    T.Contraseña = S.Contraseña,
    T.Activo = S.Activo;

DROP TABLE #Usuario;