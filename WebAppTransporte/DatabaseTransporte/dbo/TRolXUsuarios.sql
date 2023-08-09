CREATE TABLE [dbo].[TRolXUsuarios]
(
	idRolXUsuario bigint identity(1,1) not null,
	idRol bigint not null,
	idUsuario bigint not null,
	activo bit,
	primary key (idRolXUsuario),
    FOREIGN KEY (idRol) REFERENCES Admin.TRoles(idRol),
    FOREIGN KEY (idUsuario) REFERENCES TUsuarios(idUsuario) 
)
