CREATE TABLE [Admin].[TUsuariosLogeados]
(
	[IdUsuarioLogeado] BIGINT NOT NULL PRIMARY KEY, 
    [IdUsuario] BIGINT NOT NULL, 
    [RefreshTokens] NVARCHAR(1000) NOT NULL
)
