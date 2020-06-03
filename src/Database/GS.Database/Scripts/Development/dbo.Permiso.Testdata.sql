PRINT 'Loading Table #Permision'
GO

CREATE TABLE #Permiso
(
	[idPermiso] INT           NOT NULL,
    [nombre]    NVARCHAR (50) NOT NULL,
    [activo]    BIT           NOT NULL
)

INSERT INTO #Permiso ([idPermiso], [nombre], [activo]) VALUES (01, 'MODULO 1', 1)
INSERT INTO #Permiso ([idPermiso], [nombre], [activo]) VALUES (02, 'MODULO 2', 1)
INSERT INTO #Permiso ([idPermiso], [nombre], [activo]) VALUES (03, 'MODULO 3', 1)


MERGE dbo.Permiso as T
USING #Permiso as S
ON T.idPermiso = S.idPermiso
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([nombre], [activo]) VALUES (S.[nombre], S.[activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.nombre = S.nombre,
    T.activo = S.activo;

DROP TABLE #Permiso;