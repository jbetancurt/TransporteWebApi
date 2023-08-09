CREATE TABLE [dbo].[TSedes]
(
	idSede bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idCiudad bigint not null,
	idContacto bigint not null,
	nombreSede varchar(200) not null,
	telefonoSede varchar(200) not null,
	direccionSede varchar(200) not null,
	location GEOGRAPHY, 
	primary key (idSede),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa),
    FOREIGN KEY (idCiudad) REFERENCES Admin.TCiudades(idCiudad),
    FOREIGN KEY (idContacto) REFERENCES TPersonas(idPersona)
)
