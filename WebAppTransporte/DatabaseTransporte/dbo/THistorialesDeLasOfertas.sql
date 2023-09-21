CREATE TABLE [dbo].[THistorialesDeLasOfertas]
(
	idHistorialDeLaOferta bigint identity(1,1) not null,
	idUsuario bigint not null,
	idOferta bigint not null,
	idEmpresa bigint not null,
	valorActual varchar(max) not null,
	valorAnterior varchar(max) not null,
	fechaDelSuceso date null,
	versionJson int not null,
	primary key (idHistorialDeLaOferta),
    FOREIGN KEY (idUsuario) REFERENCES TUsuarios(idUsuario), 
    FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa)
)
