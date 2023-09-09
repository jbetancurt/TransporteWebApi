CREATE TABLE [Admin].[TEstadosPorRutas]
(
	idEstadoPorRuta  bigint not null identity,
	nombreEstadoPorRuta varchar(400) not null,	
	primary key (idEstadoPorRuta),
)
