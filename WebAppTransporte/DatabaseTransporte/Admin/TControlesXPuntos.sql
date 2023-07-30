CREATE TABLE [Admin].[TControlesXPuntos]
(
	idControlXPunto bigint not null,
	idTipoDeEmpresa bigint not null,
	idAdjunto bigint null,
	nombreControlXPunto varchar(200),
	valorControlXPunto varchar(200), 
	idTipoDePuntoDeControl bigint not null,
	idMenu bigint  null,
	primary key (idControlXPunto),
    FOREIGN KEY (idTipoDeEmpresa) REFERENCES Admin.TTiposDeEmpresas(idTipoDeEmpresa), 
    FOREIGN KEY (idTipoDePuntoDeControl) REFERENCES Admin.TTiposDePuntosDeControl(idTipoDePuntoDeControl), 
    FOREIGN KEY (idMenu) REFERENCES Admin.TMenus(idMenu), 
    FOREIGN KEY (idAdjunto) REFERENCES Admin.TAdjuntos(idAdjunto)
)
