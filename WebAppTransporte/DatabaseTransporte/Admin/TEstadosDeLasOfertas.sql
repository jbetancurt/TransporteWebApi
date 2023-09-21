
CREATE TABLE [Admin].[TEstadosDeLasOfertas]
(
	idEstadoDeLaOferta  bigint not null identity,
	nombreEstadoDeLaOferta varchar(400) not null,	
	primary key (idEstadoDeLaOferta),
)