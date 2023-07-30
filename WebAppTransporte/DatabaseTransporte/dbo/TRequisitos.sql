CREATE TABLE [dbo].[TRequisitos]
(
	idRequisito bigint identity(1,1) not null,
	nombreRequisito varchar(400) not null,
	idEmpresa bigint null,
	requeridoRequisito bit not null,
	adjuntoRequisito bit not null,	
	validacionUnicaRequisito bit not null,
	primary key (idRequisito),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa)
)
