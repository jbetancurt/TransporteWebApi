CREATE TABLE [dbo].[TVehiculosXEmpresas]
(
	idVehiculoXEmpresa bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idVehiculo bigint not null,
	primary key (idVehiculoXEmpresa),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idVehiculo) REFERENCES TVehiculos(idVehiculo) 
)
