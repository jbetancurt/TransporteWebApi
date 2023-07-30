CREATE TABLE [Plantillas].[TOfertas]
(
	idOferta bigint identity(1,1) not null,
	Codigo varchar(100) not null,
	idDestinoInicio bigint null,
	idDestinoFin bigint null,
	idEmpresa bigint null,
	idTipoOferta bigint null,
	Titulo varchar(100) null,
	Descripcion varchar(max) null,
	Alto decimal,
	Ancho decimal,
	Largo decimal,
	Toneladas decimal,
	ValorXTonelada decimal,
	primary key (idOferta),
    FOREIGN KEY (idTipoOferta) REFERENCES Admin.TTiposOrientacionesDeLaOferta(idTipoOrientacionDeLaOferta), --idMaestroListado = 9
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idDestinoInicio) REFERENCES TDestinos(idDestino), 
    FOREIGN KEY (idDestinoFin) REFERENCES TDestinos(idDestino)
)
