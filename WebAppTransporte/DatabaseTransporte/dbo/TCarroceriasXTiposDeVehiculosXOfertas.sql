CREATE TABLE [dbo].[TCarroceriasXTiposDeVehiculosXOfertas]
(
	idCarroceriaXTipoDeVehiculoXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idTipoDeVehiculo bigint not null,
	idTipoDeCarroceria bigint not null,
	tieneTrailer bit,
	descripcion varchar(400) not null,
	primary key (idCarroceriaXTipoDeVehiculoXOferta),
	FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
    FOREIGN KEY (idTipoDeCarroceria) REFERENCES Admin.TTiposDeCarrocerias(idTipoDeCarroceria), 
    FOREIGN KEY (idTipoDeVehiculo) REFERENCES Admin.TTiposDeVehiculos(idTipoDeVehiculo) 
)
