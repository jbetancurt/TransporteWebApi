CREATE TABLE [dbo].[TRequisitos]
(
	idRequisito bigint identity(1,1) not null,
	idEmpresa bigint null,
	nombreRequisito varchar(400) not null,
	requeridoAdjunto bit not null,
	primary key (idRequisito),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa)
)
