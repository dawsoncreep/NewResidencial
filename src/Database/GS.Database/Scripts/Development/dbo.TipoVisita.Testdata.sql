PRINT 'Loading Table #TipoVisita'
GO

CREATE TABLE #TipoVisita
(
	[idTipoVisita] INT           NOT NULL,
    [nombre]       NVARCHAR (50) NOT NULL,
    [activo]       BIT           NULL
)


INSERT INTO #TipoVisita ([idTipoVisita], [nombre], [activo]) VALUES (01, 'Preferente', 1)
INSERT INTO #TipoVisita ([idTipoVisita], [nombre], [activo]) VALUES (02, 'Preregistro', 1)
INSERT INTO #TipoVisita ([idTipoVisita], [nombre], [activo]) VALUES (03, 'Personal', 1)
INSERT INTO #TipoVisita ([idTipoVisita], [nombre], [activo]) VALUES (04, 'Evento', 1)


MERGE dbo.TipoVisita as T
USING #TipoVisita as S
ON T.idTipoVisita = S.idTipoVisita
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([nombre], [activo]) VALUES (S.[nombre], S.[activo])
WHEN MATCHED THEN 
    UPDATE SET
    T.nombre = S.nombre,
    T.activo = S.activo;

DROP TABLE #TipoVisita;