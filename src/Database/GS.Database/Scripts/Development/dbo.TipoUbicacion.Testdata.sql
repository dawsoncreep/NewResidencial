PRINT 'Loading Table #TipoUbicacion'
GO

CREATE TABLE #TipoUbicacion
(
	[Id]            INT     NOT NULL,
    [Descripcion]   NVARCHAR (50) NOT NULL,
)

INSERT INTO #TipoUbicacion ([Id], [Descripcion]) VALUES (01, 'Departamento')
INSERT INTO #TipoUbicacion ([Id], [Descripcion]) VALUES (02, 'Casa Habitacion')
INSERT INTO #TipoUbicacion ([Id], [Descripcion]) VALUES (03, 'Amenidad')


MERGE dbo.TipoUbicacion as T
USING #TipoUbicacion as S
ON T.Id = S.Id
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([Descripcion]) VALUES (S.[Descripcion])
WHEN MATCHED THEN 
    UPDATE SET
    T.Descripcion = S.Descripcion;

DROP TABLE #TipoUbicacion;