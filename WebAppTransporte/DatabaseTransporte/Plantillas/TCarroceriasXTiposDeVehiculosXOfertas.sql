CREATE TABLE [Plantillas].[TCarroceriasXTiposDeVehiculosXOfertas]
(
	idCarroceriaXTipoDeVehiculoXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idCarroceriaXTipoDeVehiculo bigint not null,
	nombrePlantillaCarroceriaXTipoDeVehiculoXOferta varchar(400) not null,
	primary key (idCarroceriaXTipoDeVehiculoXOferta),
    FOREIGN KEY (idOferta) REFERENCES Plantillas.TOfertas(idOferta), 
    FOREIGN KEY (idCarroceriaXTipoDeVehiculo) REFERENCES Admin.TCarroceriasXTiposDeVehiculos(idCarroceriaXTipoDeVehiculo) 
)

