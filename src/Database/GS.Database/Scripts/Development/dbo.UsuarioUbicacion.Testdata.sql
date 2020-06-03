PRINT 'Loading Table #UsuarioUbicacion'
GO

CREATE TABLE #UsuarioUbicacion
(
	[idUbicacion] INT NOT NULL,
    [idUsuario]   INT NOT NULL
)


-- Colonons
INSERT INTO #UsuarioUbicacion ([idUbicacion], [idUsuario]) VALUES (01, 03)
INSERT INTO #UsuarioUbicacion ([idUbicacion], [idUsuario]) VALUES (01, 04)

INSERT INTO #UsuarioUbicacion ([idUbicacion], [idUsuario]) VALUES (14, 05)

-- Guardias


MERGE dbo.UsuarioUbicacion as T
USING #UsuarioUbicacion as S
ON T.idUbicacion = S.idUbicacion AND T.idUsuario = S.idUsuario
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([idUbicacion], [idUsuario]) VALUES (S.[idUbicacion], S.[idUsuario])
WHEN MATCHED THEN 
    UPDATE SET
    T.idUbicacion = S.idUbicacion,
    T.idUsuario = S.idUsuario;

DROP TABLE #UsuarioUbicacion;