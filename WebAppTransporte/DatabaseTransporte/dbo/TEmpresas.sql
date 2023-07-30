CREATE TABLE [dbo].[TEmpresas]
(
	idEmpresa bigint identity(1,1) not null,
	idTipoDeEmpresa bigint not null,
	idContacto bigint not null,
	nombreEmpresa varchar(200) not null,
	nitEmpresa varchar(200),
	correoEmpresa varchar(200) not null,
	telefonoEmpresa varchar(200) not null,
	primary key (idEmpresa),
    FOREIGN KEY (idContacto) REFERENCES TPersonas(idPersona),
    FOREIGN KEY (idTipoDeEmpresa) REFERENCES Admin.TTiposDeEmpresas(idTipoDeEmpresa)
)
