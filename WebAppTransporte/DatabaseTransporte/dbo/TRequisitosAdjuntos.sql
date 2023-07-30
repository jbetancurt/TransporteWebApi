CREATE TABLE [dbo].[TRequisitosAdjuntos]
(
	idRequisitoAdjunto bigint identity(1,1) not null,
	idRequisito bigint not null,
	idAdjunto bigint not null,	
	primary key (idRequisitoAdjunto),
    FOREIGN KEY (idRequisito) REFERENCES TRequisitos(idRequisito),
    FOREIGN KEY (idAdjunto) REFERENCES Admin.TAdjuntos(idAdjunto)
)
