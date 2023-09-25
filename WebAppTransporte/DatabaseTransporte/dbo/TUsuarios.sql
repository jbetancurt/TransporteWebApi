CREATE TABLE [dbo].[TUsuarios]
(
	idUsuario bigint identity(1,1) not null,
	idPersona bigint not null,
	nombreUsuario varchar(200),
	claveUsuario varchar(50),
	estadoUsuario bit
	primary key (idUsuario),
    [codigoExternoUsuario] VARCHAR(200) NULL, 
    FOREIGN KEY (idPersona) REFERENCES TPersonas(idPersona) 
)
