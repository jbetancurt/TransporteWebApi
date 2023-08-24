CREATE TABLE [Admin].[TTiposDePersonasPorVehiculos]
(
	idTipoDePersonaPorVehiculo bigint not null identity,
	nombreTipoDePersonaPorVehiculo varchar(400) not null,	
	primary key (idTipoDePersonaPorVehiculo),
)
