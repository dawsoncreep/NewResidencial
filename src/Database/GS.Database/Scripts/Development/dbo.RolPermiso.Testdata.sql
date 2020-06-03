PRINT 'Loading Table #RolePermision'
GO

CREATE TABLE #RolPermiso
(
	[idRol]     INT NOT NULL,
    [idPermiso] INT NOT NULL,
    [activo]    BIT NOT NULL
)

-- Todos los roles tienen los mismo permisos
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(01, 01 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(01, 02 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(01, 03 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(02, 01 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(02, 02 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(02, 03 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(03, 01 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(03, 02 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(03, 03 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(04, 01 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(04, 02 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(04, 03 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(05, 01 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(05, 02 , 1)
INSERT INTO #RolPermiso ([idRol], [idPermiso], [activo]) VALUES(05, 03 , 1)


MERGE dbo.RolPermiso as T
USING #RolPermiso as S
ON T.idRol = S.idRol AND T.idPermiso = S.idPermiso
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([idRol], [idPermiso], [activo]) VALUES (S.[idRol], S.[idPermiso], S.[activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.idRol = S.idRol,
    T.idPermiso = S.idPermiso,
    T.activo = S.activo;

DROP TABLE #RolPermiso;