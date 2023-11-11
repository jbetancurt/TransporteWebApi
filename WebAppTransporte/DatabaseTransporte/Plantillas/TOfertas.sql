CREATE TABLE [Plantillas].[TOfertas]
(
	idOferta bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idTipoOrientacionDeLaOferta bigint not null,
	idTipoDePlantillaOferta bigint not null,
	nombrePlantillaOferta varchar(400) not null,
	tituloOferta varchar(100) not null,
	descripcionOferta varchar(max) null,
	valorTotalDeLaOferta decimal,
		
	primary key (idOferta),
    FOREIGN KEY (idTipoOrientacionDeLaOferta) REFERENCES Admin.TTiposOrientacionesDeLaOferta(idTipoOrientacionDeLaOferta), 
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idTipoDePlantillaOferta) REFERENCES Admin.TTiposDePlantillasOfertas(idTipoDePlantillaOferta)
)
