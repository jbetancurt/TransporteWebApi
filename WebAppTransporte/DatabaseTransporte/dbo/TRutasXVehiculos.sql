CREATE TABLE [dbo].[TRutasXVehiculos]
(
	idRutaXVehiculo bigint identity(1,1) not null,
	nombreRutaXVehiculo varchar(200) null,
	descripcionRutaXVehiculo varchar(max) null,
	idVehiculo bigint not null,
	idEmpresaLogistica bigint not null,
	idEmpresaContratante bigint not null,
	idEstadoRuta bigint not null,
	fechaInicioRutaXVehiculo date,
	fechaInicioRealRutaXVehiculo date,
	fechaFinRutaXVehiculo date,
	fechaFinRealRutaXVehiculo date,
	primary key (idRutaXVehiculo),
    FOREIGN KEY (idEstadoRuta) REFERENCES Admin.TEstadosPorRutas(idEstadoPorRuta), 
    FOREIGN KEY (idEmpresaLogistica) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idEmpresaContratante) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idVehiculo) REFERENCES TVehiculos(idVehiculo) 
)
