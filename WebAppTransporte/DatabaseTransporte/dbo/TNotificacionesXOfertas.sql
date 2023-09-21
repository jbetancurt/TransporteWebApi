CREATE TABLE [dbo].[TNotificacionesXOfertas]
(
	idNotificacionXOferta bigint identity(1,1) not null,
	idOferta bigint not null,
	idEmpresa bigint not null,
	idTipoDeNotificacion bigint not null,
	idEstadoDeLaNotificacion bigint not null,
	notificacionRevisada bit not null,
	
	primary key (idNotificacionXOferta),
	FOREIGN KEY (idOferta) REFERENCES TOfertas(idOferta), 
	FOREIGN KEY (idEmpresa) REFERENCES TEmpresas(idEmpresa),
	FOREIGN KEY (idTipoDeNotificacion) REFERENCES Admin.TTiposDeNotificaciones(idTipoDeNotificacion),
    FOREIGN KEY (idEstadoDeLaNotificacion) REFERENCES Admin.TEstadosDeLasNotificaciones(idEstadoDeLaNotificacion)
	
)
