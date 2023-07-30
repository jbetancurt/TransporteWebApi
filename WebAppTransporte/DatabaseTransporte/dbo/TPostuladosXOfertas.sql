CREATE TABLE [dbo].[TPostuladosXOfertas]
(
	idPostuladoXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idVehiculo bigint not null,
	primary key (idPostuladoXOferta),
    FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
    FOREIGN KEY (idVehiculo) REFERENCES TVehiculos(idVehiculo)
)
