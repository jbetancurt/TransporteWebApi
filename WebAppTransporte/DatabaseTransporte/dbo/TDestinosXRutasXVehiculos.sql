CREATE TABLE [dbo].[TDestinosXRutasXVehiculos]
(
	idDestinoXRutaXVehiculo bigint identity(1,1) not null,
	idRutaXVehiculo bigint not null,
	idCiudad bigint not null,
	idTipoDeAccionDestinoXRutaXVehiculo bigint not null,
	fechaDestinoXRutaXVehiculo date not null,
	ordenDestinoXRutaXVehiculo int not null,
	observacionDestinoXRutaXVehiculo varchar(max),
	telefonoDestinoXRutaXVehiculo varchar(100),
	direccionDestinoXRutaXVehiculo varchar(100),
	duracionEnDestinoXRutaXVehiculo int, --Duración en minutos
	location GEOGRAPHY, 
	primary key (idDestinoXRutaXVehiculo),
    FOREIGN KEY (idRutaXVehiculo) REFERENCES TRutasXVehiculos(idRutaXVehiculo), 
    FOREIGN KEY (idTipoDeAccionDestinoXRutaXVehiculo) REFERENCES Admin.TTiposDeAccionesEnDestinoDeLaRuta(idTipoDeAccionEnDestinoDeLaRuta), --idMaestroListado = 8
    FOREIGN KEY (idCiudad) REFERENCES Admin.TCiudades(idCiudad) 
)
