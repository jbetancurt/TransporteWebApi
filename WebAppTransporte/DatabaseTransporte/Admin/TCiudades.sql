CREATE TABLE [Admin].[TCiudades]
(
	idCiudad bigint identity(1,1) not null,
	idDepartamento bigint not null,
	nombreCiudad varchar(200) not null,
	codigoCiudad varchar(20),
	location GEOGRAPHY, 
	primary key (idCiudad),
    FOREIGN KEY (idDepartamento) REFERENCES Admin.TDepartamentos(idDepartamento)
)
