
CREATE TABLE [Admin].[TTiposDeLugaresXOfertas]
(
	idTipoDeLugarXOferta bigint not null identity,
	nombreTipoDeLugarXOferta varchar(400) not null,	
	[enumerador] VARCHAR(400) NULL, 
    primary key (idTipoDeLugarXOferta),
)