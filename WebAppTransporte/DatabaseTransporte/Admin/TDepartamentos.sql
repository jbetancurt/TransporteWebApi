CREATE TABLE [Admin].[TDepartamentos]
(
	idDepartamento bigint identity(1,1) not null,
	idPais bigint not null,
	nombreDepartamento varchar(200),
	codigoDepartamento varchar(20),
	location GEOGRAPHY, 
	primary key (idDepartamento),
    FOREIGN KEY (idPais) REFERENCES Admin.TPaises(idPais)
)
