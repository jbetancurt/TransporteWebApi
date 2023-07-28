CREATE TABLE [Admin].[TMenus]
(
	idMenu bigint identity(1,1) not null,
	idMenuPadre bigint null,
	nombre varchar(400) not null,	
	nombreController varchar(400) null,	
	nombreAction varchar(400) null,
	esNodo bit,
	activo bit,
	primary key (idMenu),
    FOREIGN KEY (idMenuPadre) REFERENCES Admin.TMenus(idMenu),
)
