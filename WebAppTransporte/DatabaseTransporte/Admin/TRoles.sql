CREATE TABLE [Admin].[TRoles]
(
	idRol bigint identity(1,1) not null,
	idTipoDeRol bigint not null,
	nombreRol varchar(200),
	primary key (idRol),
    FOREIGN KEY (idTipoDeRol) REFERENCES Admin.TTiposDeRoles(idTipoDeRol)
)
