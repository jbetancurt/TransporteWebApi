CREATE TABLE [Plantillas].[TOfertas]
(
	idOferta bigint identity(1,1) not null,
	codigoOferta varchar(100) not null,
	idDestinoInicio bigint null,
	idDestinoFin bigint null,
	idEmpresa bigint null,
	idTipoOrientacionDeLaOferta bigint null,
	tituloOferta varchar(100) null,
	descripcionOferta varchar(max) null,
	altoOferta decimal,
	anchoOferta decimal,
	largoOferta decimal,
	toneladasOferta decimal,
	valorXToneladaOferta decimal,
	primary key (idOferta),
    FOREIGN KEY (idTipoOrientacionDeLaOferta) REFERENCES Admin.TTiposOrientacionesDeLaOferta(idTipoOrientacionDeLaOferta), --idMaestroListado = 9
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idDestinoInicio) REFERENCES TDestinos(idDestino), 
    FOREIGN KEY (idDestinoFin) REFERENCES TDestinos(idDestino)
)
