CREATE TABLE [dbo].[TDestinosXEmpresas]
(
	idDestinoXEmpresa bigint identity(1,1) not null,
	idDestino bigint not null,
	idEmpresa bigint not null,
	idEmpresaSecundaria bigint null,
	primary key (idDestinoXEmpresa),
    FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idEmpresaSecundaria) REFERENCES TEmpresas(idEmpresa), 
    FOREIGN KEY (idDestino) REFERENCES TDestinos(idDestino)
)
