CREATE TABLE [dbo].[TLugares]
(
	idLugar bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idPersona bigint not null,
	idCiudad bigint not null,
	observacionLugar varchar(max),
	telefonoLugar varchar(100),
	direccionLugar varchar(100),
	location GEOGRAPHY, 
	primary key (idLugar),
	FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa),
    FOREIGN KEY (idPersona) REFERENCES TPersonas(idPersona),
    FOREIGN KEY (idCiudad) REFERENCES Admin.TCiudades(idCiudad) 
)
	
