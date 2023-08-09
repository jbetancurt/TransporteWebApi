CREATE TABLE [dbo].[TDestinos]
(
	idDestino bigint identity(1,1) not null,
	idContacto bigint not null,
	idCiudad bigint not null,
	observacionDestino varchar(max),
	telefonoDestino varchar(100),
	direccionDestino varchar(100),
	location GEOGRAPHY, 
	primary key (idDestino),
    FOREIGN KEY (idContacto) REFERENCES TPersonas(idPersona),
    FOREIGN KEY (idCiudad) REFERENCES Admin.TCiudades(idCiudad) 
)
