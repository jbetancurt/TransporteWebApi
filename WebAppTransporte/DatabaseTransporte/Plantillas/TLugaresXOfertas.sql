CREATE TABLE [Plantillas].[TLugaresXOfertas]
(
	idLugarXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idEmpresa bigint not null,
	idPersona bigint not null,
	idCiudad bigint not null,
	idTipoDeLugarXOferta  bigint not null,
	nombrePlantillaLugarXOferta varchar(200),
	ordenLugarXOferta int not null,
	nombreLugarXOferta varchar(200),
	observacionLugarXOferta varchar(max),
	telefonoLugarXOferta varchar(100),
	direccionLugarXOferta varchar(100),
	location GEOGRAPHY,
	primary key (idLugarXOferta),
    FOREIGN KEY (idOferta) REFERENCES Plantillas.TOfertas(idOferta), 
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa),
	FOREIGN KEY (idPersona) REFERENCES TPersonas(idPersona),
	FOREIGN KEY (idCiudad) REFERENCES Admin.TCiudades(idCiudad),
	FOREIGN KEY (idTipoDeLugarXOferta) REFERENCES Admin.TTiposDeLugaresXOfertas(idTipoDeLugarXOferta)
)
