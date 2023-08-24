CREATE TABLE [Admin].[TTiposDeVehiculos]
(
	idTipoDeVehiculo bigint not null identity,
	nombreTipoDeVehiculo varchar(400) not null,	
	primary key (idTipoDeVehiculo),
)
