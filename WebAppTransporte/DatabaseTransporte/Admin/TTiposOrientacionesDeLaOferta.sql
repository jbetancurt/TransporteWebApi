CREATE TABLE [Admin].[TTiposOrientacionesDeLaOferta]
(
    idTipoOrientacionDeLaOferta bigint not null identity,
	nombreTipoOrientacionDeLaOferta varchar(400) not null,	
	primary key (idTipoOrientacionDeLaOferta),	
)
