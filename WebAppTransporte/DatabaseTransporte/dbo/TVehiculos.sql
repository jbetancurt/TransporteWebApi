CREATE TABLE [dbo].[TVehiculos]
(
	idVehiculo bigint identity(1,1) not null,
	idCarroceriaXTipoDeVehiculo bigint not null,
	idTipoDeCarroceria bigint not null,
	idTipoDeVehiculo bigint not null,
	placaVehiculo varchar(100),
	placaTrailerVehiculo varchar(100),
	primary key (idVehiculo),
    FOREIGN KEY (idTipoDeCarroceria) REFERENCES Admin.TTiposDeCarrocerias(idTipoDeCarroceria),
	FOREIGN KEY (idCarroceriaXTipoDeVehiculo) REFERENCES Admin.TCarroceriasXTiposDeVehiculos(idCarroceriaXTipoDeVehiculo),
	FOREIGN KEY (idTipoDeVehiculo) REFERENCES Admin.TTiposDeVehiculos(idTipoDeVehiculo)
)
