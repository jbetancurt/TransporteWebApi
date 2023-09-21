﻿CREATE TABLE [dbo].[TCargasXOfertas]
(
    idCargaXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	altoCargaXOferta decimal,
	anchoCargaXOferta decimal,
	largoCargaXOferta decimal,
	toneladaCargaXOferta decimal,
	tarifaCargaXOferta decimal,
	totalCargaXOferta decimal,
	primary key (idCargaXOferta),
    FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
)
