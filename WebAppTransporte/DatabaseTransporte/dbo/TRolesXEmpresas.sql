CREATE TABLE [dbo].[TRolesXEmpresas]
(
	idRolXEmpresa bigint identity(1,1) not null,
	idRol bigint not null,
	idEmpresa bigint not null,
	activo bit,
	primary key (idRolXEmpresa),
    FOREIGN KEY (idRol) REFERENCES Admin.TRoles(idRol),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa) 
)
