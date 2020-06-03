PRINT 'Loading Table #Ubicacion'
GO

CREATE TABLE #Ubicacion
(
	[idUbicacion]     INT           NOT NULL,
    [nombre]          NVARCHAR (50) NOT NULL,
    [idTipoUbicacion] INT           NOT NULL,
    [activo]          BIT           NOT NULL,
)


-- Departamentos
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (01, 'A101', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (02, 'A102', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (03, 'A103', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (04, 'A104', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (05, 'B101', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (06, 'B102', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (07, 'B103', 01, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (08, 'B104', 01, 1)

-- Casas
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (09, 'Q100', 02, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (11, 'Q101', 02, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (12, 'Q102', 02, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (13, 'Q103', 02, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (14, 'Q104', 02, 1)

-- Comunes
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (15, 'SALON DE USO MULTIPLE', 03, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (16, 'GIMNASIO', 03, 1)
INSERT INTO #Ubicacion ([idUbicacion], [nombre], [idTipoUbicacion], [activo]) VALUES (17, 'CASETA', 03, 1)


MERGE dbo.Ubicacion T
USING #Ubicacion as S
ON T.idUbicacion = S.idUbicacion
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([nombre], [idTipoUbicacion], [activo]) VALUES (S.[nombre], S.[idTipoUbicacion], S.[activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.nombre = S.nombre,
    T.idTipoUbicacion = S.idTipoUbicacion,
    T.activo = S.activo;

DROP TABLE #Ubicacion;