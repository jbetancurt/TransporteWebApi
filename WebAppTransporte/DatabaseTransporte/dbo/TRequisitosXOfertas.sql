﻿CREATE TABLE [dbo].[TRequisitosXOfertas]
(
	idRequisitoXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idRequisito bigint not null,
	requeridoRequisitoXOferta bit not null,
	primary key (idRequisitoXOferta),
    FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
    FOREIGN KEY (idRequisito) REFERENCES TRequisitos(idRequisito)
)