
CREATE TABLE [Admin].[TTiposDeLugaresXOfertas]
(
	idTipoDeLugarXOferta bigint not null identity,
	nombreTipoDeLugarXOferta varchar(400) not null,	
	primary key (idTipoDeLugarXOferta),
)