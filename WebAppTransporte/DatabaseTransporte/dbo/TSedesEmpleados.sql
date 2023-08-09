CREATE TABLE [dbo].[TSedesEmpleados]
(
	idSedeEmpleado bigint identity(1,1) not null,
	idSede bigint not null,
	idPersona bigint not null,
	estadoSedeEmpleado bit,
	telefonoContactoSedeEmpleado varchar(100),
	primary key (idSedeEmpleado),
    FOREIGN KEY (idSede) REFERENCES TSedes(idSede),
    FOREIGN KEY (idPersona) REFERENCES TPersonas(idPersona)
)
