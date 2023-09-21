
CREATE TABLE [Admin].[TCarroceriasXTiposDeVehiculosXOfertas]
(
	idCarroceriaXTipoDeVehiculoXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idCarroceriaXTipoDeVehiculo bigint not null,
	primary key (idCarroceriaXTipoDeVehiculoXOferta),
    FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
    FOREIGN KEY (idCarroceriaXTipoDeVehiculo) REFERENCES Admin.TCarroceriasXTiposDeVehiculos(idCarroceriaXTipoDeVehiculo) 
)
