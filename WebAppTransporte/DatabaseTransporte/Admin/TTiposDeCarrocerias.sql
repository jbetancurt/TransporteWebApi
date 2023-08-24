CREATE TABLE [Admin].[TTiposDeCarrocerias]
(
	idTipoDeCarroceria bigint not null identity,
	nombreTipoDeCarroceria varchar(400) not null,	
	primary key (idTipoDeCarroceria),
)
