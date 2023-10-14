CREATE TABLE [Plantillas].[TCargasXOfertas]
(
	idCargaXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	nombrePlantillaCargaXOferta varchar(400) not null,
	tipoDeProducto varchar(400) not null,
	unidadDeEmpaque varchar(400) not null,
	altoCargaXOferta decimal,
	anchoCargaXOferta decimal,
	largoCargaXOferta decimal,
	toneladaCargaXOferta decimal,
	tarifaCargaXOferta decimal,
	totalCargaXOferta decimal,
	primary key (idCargaXOferta),
    FOREIGN KEY (idOferta) REFERENCES Plantillas.TOfertas(idOferta), 
)
