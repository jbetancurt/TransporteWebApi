CREATE TABLE [dbo].[TPersonasXVehiculos]
(
	idPersonaXVehiculo bigint identity(1,1) not null,
	idPersona bigint not null,
	idVehiculo bigint not null,
	idTipoPersonaXVehiculo bigint not null,
	primary key (idPersonaXVehiculo),
    FOREIGN KEY (idTipoPersonaXVehiculo) REFERENCES Admin.TTiposDePersonasPorVehiculos(idTipoDePersonaPorVehiculo), 
    FOREIGN KEY (idPersona) REFERENCES TPersonas(idPersona), 
    FOREIGN KEY (idVehiculo) REFERENCES TVehiculos(idVehiculo) 
)
