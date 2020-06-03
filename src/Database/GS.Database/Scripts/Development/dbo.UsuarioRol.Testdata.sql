PRINT 'Loading Table #UserRole'
GO

CREATE TABLE #UsuarioRol
(
	[idUsuario] INT NOT NULL,
    [idRol]     INT NOT NULL
)

-- Super Administrador (CEO)
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (01, 01)

-- Administrador
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (02, 02)

-- Colonos
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (03, 04)
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (04, 04)
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (05, 03)

-- Guardias
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (06, 05)
INSERT INTO #UsuarioRol ([idUsuario], [idRol]) VALUES (07, 05)


MERGE dbo.UsuarioRol as T
USING #UsuarioRol as S
ON T.idUsuario = S.idUsuario
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([idUsuario], [idRol]) VALUES (S.[idUsuario], S.[idRol])
WHEN MATCHED THEN 
    UPDATE SET
    T.idUsuario = S.idUsuario,
    T.idRol = S.idRol;

DROP TABLE #UsuarioRol;