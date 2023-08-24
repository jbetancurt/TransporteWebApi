CREATE TABLE [Admin].[TTiposDeDocumentos]
(
	idTipoDeDocumento bigint not null identity,
	nombreTipoDeDocumento varchar(400) not null,	
	primary key (idTipoDeDocumento),
)
