CREATE TABLE [dbo].[TAccesosControlXPuntos]
(
	idAccesoControlXPunto bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idControlXPunto bigint not null,
	idRol bigint not null,
	primary key (idAccesoControlXPunto),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa),
    FOREIGN KEY (idRol) REFERENCES Admin.TRoles(idRol),
    FOREIGN KEY (idControlXPunto) REFERENCES Admin.TControlesXPuntos(idControlXPunto) 
)
