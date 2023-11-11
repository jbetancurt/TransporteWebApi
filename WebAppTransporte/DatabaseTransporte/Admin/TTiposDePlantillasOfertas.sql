CREATE TABLE [Admin].[TTiposDePlantillasOfertas]
(
	idTipoDePlantillaOferta bigint not null identity,
	nombreTipoDePlantillaOferta varchar(400) not null,
	[enumerador] VARCHAR(400) NULL, 
	primary key (idTipoDePlantillaOferta),
)
