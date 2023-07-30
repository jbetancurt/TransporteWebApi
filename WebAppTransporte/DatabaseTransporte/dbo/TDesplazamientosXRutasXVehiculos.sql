CREATE TABLE [dbo].[TDesplazamientosXRutasXVehiculos]
(
	idDesplazamientoXRutaXVehiculo bigint identity(1,1) not null,
	idRutaXVehiculo bigint not null,
	fechaDesplazamientoXRutaXVehiculo date not null,
	horaDesplazamientoXRutaXVehiculo time, 
	location GEOGRAPHY, 
	primary key (idDesplazamientoXRutaXVehiculo),
    FOREIGN KEY (idRutaXVehiculo) REFERENCES TRutasXVehiculos(idRutaXVehiculo)
)
