CREATE TABLE [dbo].[TOfertas]
(
	idOferta bigint identity(1,1) not null,
	idEmpresa bigint not null,
	idTipoOrientacionDeLaOferta bigint not null,
	idEstadoDeLaOferta bigint not null,
	tituloOferta varchar(100) not null,
	descripcionOferta varchar(max) null,
	valorTotalDeLaOferta decimal,
	fechaInicialOferta date null,
	fechaFinalOferta date null,
	
	primary key (idOferta),
    FOREIGN KEY (idTipoOrientacionDeLaOferta) REFERENCES Admin.TTiposOrientacionesDeLaOferta(idTipoOrientacionDeLaOferta), 
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idEstadoDeLaOferta) REFERENCES Admin.TEstadosDeLasOfertas(idEstadoDeLaOferta)
   
)
