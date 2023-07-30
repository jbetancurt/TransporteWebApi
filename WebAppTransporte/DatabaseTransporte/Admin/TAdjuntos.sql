CREATE TABLE [Admin].[TAdjuntos]
(
	idAdjunto bigint identity(1,1) not null,
	idTipoDeArchivoAdjunto bigint not null,
	nombreAdjunto varchar(400) not null,	
	nombreArchivoAdjunto varchar(400) not null,	
	primary key (idAdjunto),
    FOREIGN KEY (idTipoDeArchivoAdjunto) REFERENCES Admin.TTiposDeArchivosAdjuntos(idTipoDeArchivoAdjunto),
)
