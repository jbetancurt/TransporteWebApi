CREATE TABLE [Admin].[TTiposDePuntosDeControl]
(
	idTipoDePuntoDeControl bigint not null identity,
	nombreTipoDePuntoDeControl varchar(400) not null,	
	primary key (idTipoDePuntoDeControl),
)
