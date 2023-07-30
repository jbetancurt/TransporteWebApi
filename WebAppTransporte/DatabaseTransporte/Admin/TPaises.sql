CREATE TABLE [Admin].[TPaises]
(
	idPais bigint identity(1,1) not null,
	nombrePais varchar(200) not null,
	codigoPais varchar(20),
	location GEOGRAPHY, 
	primary key (idPais),
)
