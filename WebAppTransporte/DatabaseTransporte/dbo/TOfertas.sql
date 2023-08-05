﻿CREATE TABLE [dbo].[TOfertas]
(
	idOferta bigint identity(1,1) not null,
	idDestinoInicio bigint not null,
	idDestinoFin bigint not null,
	idEmpresa bigint not null,
	idTipoOferta bigint not null,
	tituloOferta varchar(100) not null,
	descripcionOferta varchar(max) null,
	altoOferta decimal,
	anchoOferta decimal,
	largoOferta decimal,
	toneladasOferta decimal,
	valorXToneladaOferta decimal,
	fechaInicialOferta date null,
	fechaFinalOferta date null,
	horaInicialOferta time, 
	estadoOferta bit,
	primary key (idOferta),
    FOREIGN KEY (idTipoOferta) REFERENCES Admin.TTiposOrientacionesDeLaOferta(idTipoOrientacionDeLaOferta), 
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idDestinoInicio) REFERENCES TDestinos(idDestino), 
    FOREIGN KEY (idDestinoFin) REFERENCES TDestinos(idDestino)
)