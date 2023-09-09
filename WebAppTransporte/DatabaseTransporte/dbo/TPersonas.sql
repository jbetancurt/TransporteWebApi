CREATE TABLE [dbo].[TPersonas]
(
	idPersona bigint identity(1,1) not null,
	nombre1Persona varchar(200) not null,
	nombre2Persona varchar(200),
	apellido1Persona varchar(200) not null,
	apellido2Persona varchar(200),
	nombreCompletoPersona varchar(200) not null,
	documentoDeIdentidadPersona varchar(30) not null,
	idTipoDeDocumentoPersona bigint not null,
	correoPersona varchar(200) not null,
	telefonoPersona varchar(200) not null,
	telefonoOtroPersona varchar(200),
	direccionPersona varchar(200), 
    primary key (idPersona),
    FOREIGN KEY (idTipoDeDocumentoPersona) REFERENCES Admin.TTiposDeDocumentos(idTipoDeDocumento)
)
