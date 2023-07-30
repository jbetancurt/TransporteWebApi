CREATE TABLE [dbo].[TVehiculos]
(
	idVehiculo bigint identity(1,1) not null,
	idCarroceriaXTipoVehiculo bigint not null,
	idTipoDeCarroceria bigint not null,
	idTipoVehiculo bigint not null,
	placaVehiculo varchar(100),
	placaTrailerVehiculo varchar(100),
	primary key (idVehiculo),
    FOREIGN KEY (idTipoDeCarroceria) REFERENCES Admin.TCarroceriasXTiposDeVehiculos(idCarroceriaXTipoDeVehiculo)
)
