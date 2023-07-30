CREATE TABLE [Admin].[TCarroceriasXTiposDeVehiculos]
(
	idCarroceriaXTipoDeVehiculo bigint identity(1,1) not null,
	idTipoDeVehiculo bigint not null,
	idTipoDeCarroceria bigint not null,
	tieneTrailer bit,
	primary key (idCarroceriaXTipoDeVehiculo),
    FOREIGN KEY (idTipoDeCarroceria) REFERENCES Admin.TTiposDeCarrocerias(idTipoDeCarroceria), 
    FOREIGN KEY (idTipoDeVehiculo) REFERENCES Admin.TTiposDeVehiculos(idTipoDeVehiculo) 
)
