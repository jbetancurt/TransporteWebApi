CREATE TABLE [Admin].[TTiposDeArchivosAdjuntos]
(
	idTipoDeArchivoAdjunto bigint not null identity,
	nombreTipoDeArchivoAdjunto varchar(400) not null,	
	primary key (idTipoDeArchivoAdjunto),
)
