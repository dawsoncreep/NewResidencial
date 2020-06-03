PRINT 'Loading Table #Role'
GO

CREATE TABLE #Rol
(
	[idRol]  INT           NOT NULL,
    [nombre] NVARCHAR (50) NOT NULL,
    [activo] BIT           NOT NULL
)


INSERT INTO #Rol ([idRol], [nombre], [activo]) VALUES (01, 'CEO', 1)
INSERT INTO #Rol ([idRol], [nombre], [activo]) VALUES (02, 'Administrador', 1)
INSERT INTO #Rol ([idRol], [nombre], [activo]) VALUES (03, 'Representante', 1)
INSERT INTO #Rol ([idRol], [nombre], [activo]) VALUES (04, 'Habitante', 1)
INSERT INTO #Rol ([idRol], [nombre], [activo]) VALUES (05, 'Guardia', 1)


MERGE dbo.Rol as T
USING #Rol as S
ON T.idRol = S.idRol
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([nombre], [activo]) VALUES (S.[nombre], S.[activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.nombre = S.nombre,
    T.activo = S.activo;

DROP TABLE #Rol;
