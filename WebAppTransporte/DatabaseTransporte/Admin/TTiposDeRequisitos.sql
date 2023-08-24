CREATE TABLE [Admin].[TTiposDeRequisitos]
(
	idTipoDeRequisito bigint not null identity,
	nombreTipoDeRequisito varchar(400) not null,	
	primary key (idTipoDeRequisito),
)
