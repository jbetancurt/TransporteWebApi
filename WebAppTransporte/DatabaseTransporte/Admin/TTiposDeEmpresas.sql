CREATE TABLE [Admin].[TTiposDeEmpresas]
(
	idTipoDeEmpresa bigint not null identity,
	nombreTipoDeEmpresa varchar(400) not null,	
	primary key (idTipoDeEmpresa),
)
