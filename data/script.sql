CREATE SCHEMA AEFI AUTHORIZATION gd;

GO


CREATE TABLE [AEFI].[TL_Usuario](
	[ID_Usuario] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[Username] NVARCHAR(255) NOT NULL UNIQUE,
	[Password] NVARCHAR(64) NOT NULL,
	[Pass_Temporal] bit DEFAULT 1, /*1 VERDADERO, 0 FALSO */
	[Habilitado] bit DEFAULT 1,
		[Nombre] NVARCHAR(255),
		[Apellido] NVARCHAR(255),
		[ID_Tipo_Documento] nvarchar(255),
		[Documento_Nro] NUMERIC(18,0),	
		[Mail] nvarchar(255) UNIQUE, 
		[Telefono]nvarchar(20),		
		[Calle] NVARCHAR (255),
		[Calle_Nro] NUMERIC(18,0),
		[Piso] NUMERIC(18,0),
		[Dpto] NVARCHAR(50),
		[Fecha_Nacimiento] datetime

);



		
CREATE TABLE [AEFI].[TL_Cliente](
	
		[ID_Cliente] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[Nombre] NVARCHAR(255),
		[Apellido] NVARCHAR(255),
		[ID_Tipo_Documento] nvarchar(255),
		[Documento_Nro] NUMERIC(18,0),
		[Mail] nvarchar(255), /*UNIQUE: QUITE ESTO PORQUE HAY MAILS REPETIDOS Y NO PODEMOS PERDER DATOS */
		[Calle] NVARCHAR (255),
		[Calle_Nro] NUMERIC(18,0),
		[Piso] NUMERIC(18,0),
		[Dpto] NVARCHAR(50),
		[Telefono] nvarchar(20),		
		[Fecha_Nacimiento] datetime,
		[Nacionalidad] NVARCHAR(255),
		[Localidad] NVARCHAR(255), 
		[PaisOrigen] NVARCHAR(255)
		);
	


CREATE TABLE [AEFI].[TL_Rol](
	[ID_Rol] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] nvarchar (255) UNIQUE NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1

);	



CREATE TABLE [AEFI].[TL_Funcionalidad](
	[ID_Funcionalidad] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] nvarchar (255) UNIQUE NOT NULL,
	[Restriccion] int DEFAULT NULL, /*si esta en NULL no hay restriccion, si tiene un numero es el numero del rol al que puede ser asignado*/
);

CREATE TABLE [AEFI].[TL_Regimen] (
		[ID_Regimen] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[Descripcion] NVARCHAR(255),
		[Precio_Base] NUMERIC(18,2),
		[Estado] bit DEFAULT 1 /*1 activo 0 no activo */
);		

CREATE TABLE [AEFI].[TL_Hotel](
		[ID_Hotel] NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
		[Nombre] nvarchar(55),	
		[Mail] nvarchar(255),	
		[Telefono] nvarchar(20),
		[Calle] nvarchar(255),
		[Nro_Calle] NUMERIC(18,0),
		[Cantidad_Estrellas] NUMERIC(18,0),
		[Recarga_Estrellas] NUMERIC(18,0),
		[Ciudad] nvarchar(255),
		[Pais] nvarchar(255),
		[Fecha_Creacion] datetime,
		[Estado] varchar(50)
		
		);
		
CREATE TABLE [AEFI].[TL_Habitacion](

		[ID_Habitacion] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[ID_Tipo_Habitacion] NUMERIC(18,0),
		[Numero] numeric(18,0),
		[Piso] numeric (18,0),
		[Vista] nvarchar(50),
		[Estado] varchar(255),
		[Disponible] nvarchar(2),
		[ID_Hotel] NUMERIC(18,0),
		FOREIGN KEY (ID_Hotel) REFERENCES [AEFI].[TL_Hotel] (ID_Hotel)
		);


CREATE TABLE [AEFI].[TL_Tipo_Habitacion](
		[ID_Tipo_Habitacion] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY, /*EX TIPO_CODIGO DE HABITACION*/
		[Descripcion] NVARCHAR(255),
		[Porcentual] NUMERIC(18,2),
		[Cantidad_Huespedes_Total] NUMERIC(18,0),
		);

CREATE TABLE [AEFI].[TL_Baja_Hotel](
		[ID_Baja] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY, /* Nueva tabla para las bajas de hoteles */
		[Fecha_Inicio] datetime,
		[Fecha_Fin] datetime,
		[Descripcion] varchar(255),
		[ID_Hotel] NUMERIC (18,0),
		FOREIGN KEY (ID_Hotel) REFERENCES [AEFI].[TL_Hotel] (ID_Hotel)
		);
		
		
		
CREATE TABLE [AEFI].[TL_Reserva](

		[ID_Reserva] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY, /*EX RESERVA CODIGO*/
		[Fecha_Reserva] datetime,
		[Fecha_Desde] datetime,
		[Cantidad_Huespedes] NUMERIC(18,0),
		[Cantidad_Noches] NUMERIC(18,0), 
		[ID_Regimen] NUMERIC(18,0) NOT NULL,
		[ID_Habitacion] NUMERIC(18,0) NOT NULL,
		[ID_Cliente] NUMERIC(18,0) NOT NULL,
		FOREIGN KEY (ID_Cliente) REFERENCES [AEFI].[TL_Cliente] (ID_Cliente),
		FOREIGN KEY (ID_Habitacion) REFERENCES [AEFI].[TL_Habitacion] (ID_Habitacion),
		FOREIGN KEY (ID_Regimen) REFERENCES [AEFI].[TL_Regimen] (ID_Regimen)	
		
);

		
		
CREATE TABLE [AEFI].[TL_Cancelacion](
		
		[ID_Cancelacion] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY, /*ver bien que tipo es*/
		[Motivo] nvarchar(255),
		[ID_Reserva] NUMERIC(18,0),
		[Fecha] datetime,
		[ID_Usuario] NUMERIC(18,0),		
		FOREIGN KEY (ID_Usuario) REFERENCES [AEFI].[TL_Usuario] (ID_Usuario), /*Usuario que hizo la cancelación*/
		FOREIGN KEY (ID_Reserva) REFERENCES [AEFI].[TL_Reserva] (ID_Reserva)
);

CREATE TABLE [AEFI].[TL_Consumible](

		[ID_Consumible] NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,/*ex codigo*/
		[Descripcion] NVARCHAR(255),
		[Precio] NUMERIC(18,2)
);		
		
CREATE TABLE [AEFI].[TL_FormaDePago] (
	[ID_FormaDePago] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] NVARCHAR(50)
);

		
CREATE TABLE [AEFI].[TL_Factura](

		[ID_Factura] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[Numero] NUMERIC(18,0),
		[Fecha] datetime,
		[Total] NUMERIC(18,2),
		[ID_FormaDePago] NUMERIC(18,0),
		[ID_Cliente] NUMERIC(18,0),
		FOREIGN KEY (ID_FormaDePago) REFERENCES [AEFI].[TL_FormaDePago] (ID_FormaDePago),
		FOREIGN KEY (ID_Cliente) REFERENCES [AEFI].[TL_Cliente] (ID_Cliente)
		
);
	


CREATE TABLE [AEFI].[TL_Estadia](
		
		[ID_Estadia] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[Estado] bit, /*1 activo, 0 finalizado*/
		[Fecha_Inicio] datetime,
		[Cantidad_Noches] NUMERIC(18,0),
		[ID_Reserva] NUMERIC(18,0),
		[ID_Factura] NUMERIC(18,0),
		FOREIGN KEY (ID_Reserva) REFERENCES [AEFI].[TL_Reserva](ID_Reserva),
		FOREIGN KEY (ID_Factura) REFERENCES [AEFI].[TL_Factura](ID_Factura)
				);




CREATE TABLE [AEFI].[TL_Tipo_Documento](
		[ID_Tipo_Documento] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
		[Descripcion] NVARCHAR(40)
);


CREATE TABLE [AEFI].[TL_Registro_Pago](
		[ID_Factura] NUMERIC(18,0),
		[ID_Cliente] NUMERIC(18,0),
		[Fecha] DATETIME,
		[ID_Tarjeta] NUMERIC(18,0)
		PRIMARY KEY (ID_Factura, ID_Cliente),
		FOREIGN KEY (ID_Factura) REFERENCES [AEFI].[TL_Factura] (ID_Factura),
		FOREIGN KEY (ID_Cliente) REFERENCES [AEFI].[TL_Cliente] (ID_Cliente)
);
		
CREATE TABLE [AEFI].[TL_Tarjeta](
	[ID_Tarjeta] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[Numero] NUMERIC(18,0),
	[Fecha_Vto] DATETIME
);

		
/* TABLA MUCHOS A MUCHOS*/
CREATE TABLE [AEFI].[TL_Funcionalidad_Rol] (
	[ID_Rol] NUMERIC(18,0),
	[ID_Funcionalidad] NUMERIC(18,0),
	PRIMARY KEY (ID_Rol, ID_Funcionalidad),
	FOREIGN KEY (ID_Rol) REFERENCES [AEFI].[TL_ROL] (ID_Rol),
	FOREIGN KEY (ID_Funcionalidad) REFERENCES [AEFI].[TL_Funcionalidad] (ID_Funcionalidad)
);
	
/*TABLA MUCHOS A MUCHOS*/	
CREATE TABLE [AEFI].[TL_Usuario_Por_Rol](

		[ID_Rol] NUMERIC(18,0),
		[ID_Usuario] NUMERIC(18,0),
		PRIMARY KEY (ID_Usuario, ID_Rol),
		FOREIGN KEY (ID_Usuario) REFERENCES [AEFI].[TL_Usuario] (ID_Usuario),
		FOREIGN KEY (ID_Rol) REFERENCES [AEFI].[TL_Rol] (Id_Rol)
);
		
/*TABLA MUCHOS A MUCHOS */
CREATE TABLE [AEFI].[TL_Item_Por_Factura](
	[ID_Item_Por_Factura] NUMERIC(18,0) IDENTITY (1,1) PRIMARY KEY,
	[ID_Consumible] NUMERIC(18,0),
	[Cantidad] NUMERIC(18,0),
	[ID_Factura] NUMERIC(18,0),
	[ID_Estadia] NUMERIC(18,0),
	[Monto] NUMERIC(18,2),
	FOREIGN KEY (ID_Factura) REFERENCES [AEFI].[TL_Factura] (ID_Factura),
	FOREIGN KEY (ID_Consumible) REFERENCES [AEFI].[TL_Consumible] (ID_Consumible),
	FOREIGN KEY (ID_Estadia) REFERENCES [AEFI].[TL_Estadia](ID_Estadia)
	
);

/*TABLA MUCHOS A MUCHOS */
CREATE TABLE [AEFI].[TL_Regimen_Por_Hotel](
	[ID_Hotel] NUMERIC(18,0),
	[ID_Regimen] NUMERIC(18,0),
	PRIMARY KEY (ID_Hotel, ID_Regimen),
	FOREIGN KEY (ID_Hotel) REFERENCES [AEFI].[TL_Hotel] (ID_Hotel),
	FOREIGN KEY (ID_Regimen) REFERENCES [AEFI].[TL_Regimen] (ID_Regimen)
);

/*TABLA MUCHOS A MUCHOS */
CREATE TABLE [AEFI].[TL_Usuario_Por_Hotel](
	[ID_Usuario_Hotel] NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	[ID_Hotel] NUMERIC(18,0),
	[ID_Usuario] NUMERIC(18,0),
	[ID_Rol] NUMERIC(18,0),
	FOREIGN KEY (ID_Hotel) REFERENCES [AEFI].[TL_Hotel] (ID_Hotel),
	FOREIGN KEY (ID_Usuario) REFERENCES [AEFI].[TL_Usuario] (ID_Usuario),
	FOREIGN KEY (ID_Rol) REFERENCES [AEFI].[TL_Rol] (ID_Rol)
	
);
  
/*TABLA MUCHOS A MUCHOS */
CREATE TABLE [AEFI].[TL_Consumible_Por_Estadia](
	[ID_Consumible_Por_Estadia] NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	[ID_Consumible] NUMERIC(18,0),
	[ID_Estadia] NUMERIC(18,0),
	FOREIGN KEY (ID_Consumible) REFERENCES [AEFI].[TL_Consumible] (ID_Consumible),
	FOREIGN KEY (ID_Estadia) REFERENCES [AEFI].[TL_Estadia] (ID_Estadia)
);

/*Comienzo de INSERTS */

BEGIN TRANSACTION

INSERT INTO [AEFI].[TL_Tipo_Documento] (Descripcion)
VALUES ('DNI'), ('PA'), ('CUIL'), ('LE');

INSERT INTO [AEFI].[TL_Usuario](Username, Password) 
VALUES ('admin','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7')

INSERT INTO [AEFI].[TL_Rol] (Descripcion) 
VALUES ('Guest'),('Recepcionista'),('Administrador');;

INSERT INTO [AEFI].[TL_Funcionalidad] (Descripcion)
VALUES ('ABM de Rol'), ('ABM de Usuario'), ('ABM de Cliente (Huespedes)'), ('ABM de Hotel'), ('ABM de Habitacion'), ('ABM de Regimen de Estadia'),
	('Generar o Modificar una Reserva'), ('Cancelar Reserva'), ('Registrar Estadía (check-in/check-out)'), ('Registrar Consumibles'), ('Facturar Estadia'), ('Listado Estadistico');

INSERT INTO AEFI.TL_Usuario_Por_Rol(ID_Rol, ID_Usuario)
SELECT r.ID_Rol,  u.ID_Usuario
FROM AEFI.TL_Rol r, AEFI.TL_Usuario u
WHERE u.Username = 'admin';

UPDATE AEFI.TL_Funcionalidad
SET Restriccion = x.ID_Rol
FROM AEFI.TL_Rol x, AEFI.TL_Funcionalidad r
WHERE r.Descripcion = 'ABM de Usuario'
AND x.Descripcion = 'Administrador';


/* FUNCIONALIDADES DE GUEST */
INSERT INTO [AEFI].[TL_Funcionalidad_Rol](ID_Rol, ID_Funcionalidad)
VALUES (1,7),(1,8);

/*FUNCIONALIDADES DE RECEPCIONISTA*/
INSERT INTO [AEFI].[TL_Funcionalidad_Rol]
VALUES (2,3),(2,7), (2,8), (2,9), (2,10), (2,11);

/*FUNCIONALIDAD DE ADMINISTRADOR*/
INSERT INTO [AEFI].[TL_Funcionalidad_Rol]
VALUES (3,1),(3,2),(3,4),(3,5),(3,6),(3,12);

/*FORMAS DE PAGO*/

INSERT INTO [AEFI].[TL_FormaDePago] (Descripcion)
VALUES ('Efectivo'), ('Tarjeta de Crédito');

COMMIT

/*FIN DE INSERTS */

/*COMIENZO DE MIGRACION*/
BEGIN TRANSACTION

INSERT INTO AEFI.TL_Cliente(Nombre,Apellido,ID_Tipo_Documento,Documento_Nro,Mail,Calle,Calle_Nro,Piso,Dpto,Fecha_Nacimiento,Nacionalidad,Localidad,PaisOrigen)
SELECT DISTINCT m.Cliente_Nombre, m.Cliente_Apellido ,2, m.Cliente_Pasaporte_Nro, m.Cliente_Mail, m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, m.Cliente_Fecha_Nac, m.Cliente_Nacionalidad,'CABA','Argentina' 
FROM gd_esquema.Maestra m
WHERE Cliente_Apellido IS NOT NULL AND Cliente_Nombre IS NOT NULL

INSERT INTO [AEFI].[TL_Hotel](Nombre, Calle, Nro_Calle,Ciudad,Cantidad_Estrellas,Recarga_Estrellas, Pais, Estado)
SELECT DISTINCT 'Hotel '+ Hotel_Calle, Hotel_Calle, Hotel_Nro_Calle, Hotel_Ciudad, Hotel_CantEstrella, Hotel_Recarga_Estrella, 'Argentina', 'Habilitado'
FROM gd_esquema.Maestra


SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion ON
INSERT INTO AEFI.TL_Tipo_Habitacion(ID_Tipo_Habitacion, Descripcion, Porcentual)
SELECT DISTINCT m.Habitacion_Tipo_Codigo, m.Habitacion_Tipo_Descripcion, m.Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra m
SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion OFF


UPDATE AEFI.TL_Tipo_Habitacion 
SET Cantidad_Huespedes_Total = 2
WHERE Descripcion = 'Base Doble' OR Descripcion = 'King'

UPDATE AEFI.TL_Tipo_Habitacion
SET Cantidad_Huespedes_Total = 3
WHERE Descripcion = 'Base Triple'

UPDATE AEFI.TL_Tipo_Habitacion 
SET Cantidad_Huespedes_Total = 4
WHERE Descripcion = 'Base Cuadruple'

UPDATE AEFI.TL_Tipo_Habitacion
SET Cantidad_Huespedes_Total = 1
WHERE Descripcion = 'Base Simple'


INSERT INTO [AEFI].[TL_Habitacion] (ID_Tipo_Habitacion, Numero, Piso, Vista, ID_Hotel, Estado, Disponible)
SELECT DISTINCT t.ID_Tipo_Habitacion, m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.ID_Hotel, 'Habilitado', 'Si'
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Tipo_Habitacion t ON (m.Habitacion_Tipo_Codigo = t.ID_Tipo_Habitacion)
JOIN AEFI.TL_Hotel h ON (h.Calle = m.Hotel_Calle AND h.Nro_Calle=m.Hotel_Nro_Calle)


INSERT INTO [AEFI].[TL_Regimen] (Descripcion,Precio_Base, Estado)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio, 1
FROM  gd_esquema.Maestra


SET IDENTITY_INSERT AEFI.TL_Reserva ON
INSERT INTO [AEFI].[TL_Reserva] (ID_Reserva, Fecha_Desde, Cantidad_Noches, Cantidad_Huespedes, ID_Cliente, ID_Habitacion, ID_Regimen)
SELECT DISTINCT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, x.Cantidad_Huespedes_Total, c.ID_Cliente, h.ID_Habitacion, r.ID_Regimen
FROM gd_esquema.Maestra m

JOIN AEFI.TL_Tipo_Habitacion x ON (m.Habitacion_Tipo_Codigo= x.ID_Tipo_Habitacion) 
JOIN AEFI.TL_Cliente c ON (m.Cliente_Pasaporte_Nro = c.Documento_Nro AND m.Cliente_Apellido= c.Apellido AND m.Cliente_Nombre= c.Nombre)
JOIN AEFI.TL_Habitacion  h ON (m.Habitacion_Numero = h.ID_Habitacion)
JOIN AEFI.TL_Regimen r ON (m.Regimen_Descripcion = r.Descripcion)
SET IDENTITY_INSERT AEFI.TL_Reserva OFF

	

--Uso codigos que ya existen
	SET IDENTITY_INSERT [AEFI].[TL_Consumible] ON
	INSERT INTO [AEFI].[TL_Consumible](ID_Consumible, Descripcion, Precio)
	SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	FROM gd_esquema.Maestra 
	WHERE Consumible_Codigo IS NOT NULL
	SET IDENTITY_INSERT [AEFI].[TL_Consumible] OFF




INSERT INTO [AEFI].[TL_Factura](Numero, Fecha, Total, ID_Cliente)
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, x.ID_Cliente
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Cliente x ON (x.Documento_Nro = m.Cliente_Pasaporte_Nro)
WHERE m.Factura_Nro IS NOT NULL;


INSERT INTO [AEFI].[TL_Estadia](ID_Reserva, Fecha_Inicio, Cantidad_Noches, Estado)
SELECT DISTINCT r.ID_Reserva, m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches, 1
FROM gd_esquema.Maestra m, AEFI.TL_Reserva r
WHERE r.ID_Reserva = m.Reserva_Codigo
AND m.Estadia_Cant_Noches IS NOT NULL AND m.Estadia_Fecha_Inicio IS NOT NULL
AND m.Factura_Total IS NULL;


INSERT INTO [AEFI].[TL_Estadia](ID_Reserva, Fecha_Inicio, Cantidad_Noches,Estado, ID_Factura)
SELECT DISTINCT r.ID_Reserva, m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches, 0, f.ID_Factura
FROM gd_esquema.Maestra m, AEFI.TL_Reserva r, AEFI.TL_Factura f
WHERE r.ID_Reserva = m.Reserva_Codigo
AND f.Numero = m.Factura_Nro
AND m.Estadia_Cant_Noches IS NOT NULL AND m.Estadia_Fecha_Inicio IS NOT NULL
AND m.Factura_Total IS NOT NULL;


INSERT INTO AEFI.TL_Consumible_Por_Estadia
SELECT c.ID_Consumible, e.ID_Estadia
FROM gd_esquema.Maestra m, AEFI.TL_Consumible c, AEFI.TL_Estadia e
WHERE m.Consumible_Codigo = c.ID_Consumible AND e.ID_Reserva=m.Reserva_Codigo;



COMMIT

/*FIN DE MIGRACION*/

/*STORED PROCEDURES */

GO

CREATE PROCEDURE AEFI.crear_Hotel

		@ID_Hotel nvarchar(10),
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono nvarchar(20),
		@Calle nvarchar(255),
		@Cantidad_Estrellas numeric(18,0),
		@Ciudad nvarchar(255),
		@Pais nvarchar(255),
		@Fecha_Creacion datetime,
		@NroCalle numeric(18,0),
		@Recarga_Estrellas nvarchar(50)

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Hotel h WHERE Nombre = @Nombre AND Nro_Calle = @NroCalle)
	BEGIN
			INSERT INTO AEFI.TL_Hotel(Nombre, Mail, Telefono, Calle, Cantidad_Estrellas, Ciudad, Pais, Fecha_Creacion, Nro_Calle, Recarga_Estrellas)
			VALUES (@Nombre, @Mail, @Telefono, @Calle, @Cantidad_Estrellas, @Ciudad, @Pais, @Fecha_Creacion, @NroCalle, @Recarga_Estrellas)
	END;

END;


GO

CREATE PROCEDURE AEFI.actualizar_Hotel

		@ID_Hotel numeric(18,0),
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono nvarchar(20),
		@Calle nvarchar(255),
		@Cantidad_Estrellas numeric(18,0),
		@Recarga_Estrellas numeric(18,0),
		@Ciudad nvarchar(255),
		@Pais nvarchar(255),
		@NroCalle numeric(18,0)

AS
BEGIN
	
	BEGIN
    
    UPDATE AEFI.TL_Hotel
	SET Nombre =@Nombre, Mail = @Mail, Telefono = @Telefono, Calle = @Calle, Cantidad_Estrellas = @Cantidad_Estrellas, Ciudad = @Ciudad, Pais = @Pais, Nro_Calle = @NroCalle
	WHERE ID_Hotel = @ID_Hotel
						
	END;	
			
END;	
	
	

GO

/* Se podria implementar un Trigger o algo asi para habilitarlo cuando termine el plazo (hay q ver ) */
CREATE PROCEDURE AEFI.baja_Hotel

		@ID_Hotel numeric(18,0),
		@Fecha_Inicio datetime,
		@Fecha_Fin datetime,
		@Descripcion varchar(255)

AS

/* Falta realizar la validacion de estadia de hoteles, si esta vacio y todo eso */

BEGIN
										
	INSERT INTO AEFI.TL_Baja_Hotel (Fecha_Inicio, Fecha_Fin, Descripcion, ID_Hotel)
	VALUES (@Fecha_Inicio, @Fecha_Fin, @Descripcion, @ID_Hotel)
	
	UPDATE AEFI.TL_Hotel
	SET Estado = 'Deshabilitado'
	WHERE @ID_Hotel = ID_Hotel

	
END;
	
	
GO	
	
CREATE PROCEDURE AEFI.crear_Habitacion


/*por alguna razon si les pongo numeric no puede tranformar nvarchar a numeric, por eso son nvarchar (funciona) */
		@ID_Habitacion nvarchar(10),
		@Numero nvarchar(50),
		@Piso nvarchar(50),
		@Vista nvarchar (50),
		@Tipo_Habitacion nvarchar(50)
		

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Habitacion h WHERE Numero = @Numero)	
	
	BEGIN
			INSERT INTO AEFI.TL_Habitacion(Numero, Piso, Vista, ID_Tipo_Habitacion)
			VALUES (@Numero, @Piso, @Vista, (SELECT ID_Tipo_Habitacion 
	FROM AEFI.TL_Tipo_Habitacion th
	WHERE th.Descripcion = @Tipo_Habitacion))
	END;

END;



GO
CREATE PROCEDURE AEFI.actualizar_Habitacion

		@ID_Hotel numeric(18,0),
		@ID_Habitacion numeric(18,0),
		@Numero numeric(18,0),
		@Piso numeric(18,0),
		@Vista nvarchar (50)
		

AS
BEGIN
	
	BEGIN
    
    UPDATE AEFI.TL_Habitacion
	SET Numero =@Numero, Piso = @Piso, Vista = @Vista
	WHERE ID_Habitacion = @ID_Habitacion
	AND ID_Hotel = @ID_Hotel
						
	END;	
			
END;	


GO

CREATE PROCEDURE AEFI.baja_Habitacion
	@ID_Habitacion NVARCHAR(255)
	
AS
BEGIN
	UPDATE AEFI.TL_Habitacion
	SET Estado = 'Deshabilitado'
	WHERE ID_Habitacion = @ID_Habitacion
	
	
END;


GO

CREATE PROCEDURE AEFI.insertar_cliente
    @Nombre NVARCHAR(255),
    @Apellido NVARCHAR(255),
    @ID_Tipo_Documento NVARCHAR(255),
    @Documento_Numero NUMERIC(18,0),
    @Mail NVARCHAR(255),
    @Calle NVARCHAR(255),
    @Calle_Nro NUMERIC(18,0),
    @Piso NUMERIC(18,0) = NULL,
    @Dpto NVARCHAR(50) = NULL,
    @Telefono NUMERIC(18,0),
    @Fecha_Nacimiento DATETIME,
    @Localidad NVARCHAR(255) = NULL,
    @PaisOrigen NVARCHAR(255)
		
AS
BEGIN
	IF @localidad IS NOT NULL
	BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Localidad = @Localidad)
			INSERT INTO AEFI.TL_Cliente(Localidad)
			VALUES (@Localidad);
	END;
	
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Calle = @Calle AND Calle_Nro = @Calle_Nro)
	BEGIN
		IF @localidad IS NOT NULL
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto, Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto,
			(
				SELECT Localidad
				FROM AEFI.TL_Cliente
				WHERE Localidad = @Localidad)
			);
		ELSE
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto, Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto, NULL);
	END;
	
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario WHERE Username = @Nombre + '_' + @Apellido)
	BEGIN
		INSERT INTO AEFI.TL_Usuario (Username, Password)
		VALUES (@Nombre + '_' + @Apellido, '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4'); /* 1234 */
		INSERT INTO AEFI.TL_Usuario_Por_Rol(ID_Usuario, ID_Rol)
		VALUES ((SELECT ID_Usuario FROM AEFI.TL_Usuario WHERE Username = @Nombre + '_' + @Apellido), 1);
	END;
	
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Nombre = @Nombre AND Apellido = @Apellido)
		INSERT INTO AEFI.TL_Cliente (Documento_Nro, Nombre, Apellido, Telefono, Mail, Fecha_Nacimiento, ID_Tipo_Documento, Calle, ID_Cliente)
		VALUES (@Documento_Numero, @Nombre, @Apellido, @Telefono, @Mail, @Fecha_Nacimiento, (
			SELECT ID_Tipo_Documento
			FROM AEFI.TL_Tipo_Documento
			WHERE Descripcion = @ID_Tipo_Documento), (
			SELECT Calle
			FROM AEFI.TL_Cliente
			WHERE Calle = @Calle AND Calle_Nro = @Calle_Nro), (
			SELECT ID_Usuario
			FROM AEFI.TL_Usuario
			WHERE Username = @Nombre + '_' + @Apellido));
END;

GO

CREATE PROCEDURE AEFI.actualizar_cliente
	@ID_Cliente NUMERIC(18,0),
	@Nombre NVARCHAR(255),
    @Apellido NVARCHAR(255),
    @ID_Tipo_Documento NVARCHAR(255),
    @Documento_Numero NUMERIC(18,0),
    @Mail NVARCHAR(255),
    @Calle NVARCHAR(255),
    @Calle_Nro NUMERIC(18,0),
    @Piso NUMERIC(18,0) = NULL,
    @Dpto NVARCHAR(50) = NULL,
    @Telefono nvarchar(20),
    @Fecha_Nacimiento DATETIME,
    @Localidad NVARCHAR(255) = NULL,
    @PaisOrigen NVARCHAR(255)
AS
BEGIN
	IF @localidad IS NOT NULL
	BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Localidad = @Localidad)
			INSERT INTO AEFI.TL_Cliente(Localidad)
			VALUES (@Localidad);
	END;

	IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Calle = @Calle
		AND Calle_Nro = @Calle_Nro AND Piso = @Piso AND Dpto = @Dpto)
	BEGIN
		IF @Localidad IS NOT NULL
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto, Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto,
			(
				SELECT Localidad
				FROM AEFI.TL_Cliente
				WHERE Localidad = @localidad AND ID_Cliente = @ID_Cliente)
			);
		ELSE
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto,  Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto, NULL);
	END;
	
	UPDATE AEFI.TL_Cliente
	SET ID_Tipo_Documento = (
		SELECT ID_Tipo_Documento
		FROM AEFI.TL_Tipo_Documento
		WHERE Descripcion = @ID_Tipo_Documento), Documento_Nro = @Documento_Numero, Mail = @Mail, Telefono = @Telefono, Fecha_Nacimiento = @Fecha_Nacimiento, Calle = @Calle	
END;

GO

CREATE PROCEDURE AEFI.insertar_rol_funcionalidad
 @ID_Funcionalidad NUMERIC(18,0),
 @ID_rol NUMERIC(18,0)
AS
BEGIN
 IF NOT EXISTS (SELECT * FROM AEFI.TL_Funcionalidad_Rol WHERE ID_Funcionalidad = @ID_Funcionalidad AND ID_Rol = @ID_rol)
 INSERT INTO AEFI.TL_Funcionalidad_Rol VALUES (@ID_Rol, @ID_Funcionalidad)
END;


GO

CREATE PROCEDURE AEFI.eliminar_funcionalidad_rol
 @ID_Funcionalidad NUMERIC(18,0),
 @ID_Rol NUMERIC(18,0)
AS
BEGIN
 IF EXISTS (SELECT * FROM AEFI.TL_Funcionalidad_Rol WHERE ID_Funcionalidad = @ID_funcionalidad AND ID_Rol = @ID_Rol)
 DELETE AEFI.TL_Funcionalidad_Rol WHERE ID_Rol = @ID_Rol AND ID_Funcionalidad = @ID_Funcionalidad
END;

GO
CREATE PROCEDURE AEFI.inhabilitar_rol
 @ID_rol NUMERIC(18,0)
AS
BEGIN
 UPDATE AEFI.TL_Rol
 SET Activo = 0
 WHERE ID_Rol = @ID_rol;

END;

GO
CREATE PROCEDURE AEFI.habilitar_rol
 @ID_rol NUMERIC(18,0)
AS
BEGIN
 UPDATE AEFI.TL_Rol
 SET Activo = 1
 WHERE ID_Rol = @ID_rol;

END;

GO
CREATE PROCEDURE AEFI.crear_usuario

 @Username nvarchar(255),
 @Password nvarchar(64),
 @Nombre nvarchar(255),
 @Apellido nvarchar(255),
 @id_tipo_documento nvarchar(255),
 @documento_nro numeric(18,0),
 @telefono nvarchar(20),
 @calle nvarchar(255),
 @calle_nro numeric(18,0),
 @piso numeric(18,0),
 @dpto nvarchar(50),
 @mail nvarchar(255),
 @fecha_nacimiento datetime

AS
BEGIN
 IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario u WHERE Username = @Username OR Mail=@mail OR (Documento_Nro = @documento_nro AND ID_Tipo_Documento = @id_tipo_documento))
 BEGIN
 INSERT INTO AEFI.TL_Usuario(Username, Password, Pass_Temporal, Habilitado, Nombre, Apellido, ID_Tipo_Documento, Documento_Nro, Mail, Telefono, Calle, Calle_Nro, Piso, Dpto, Fecha_Nacimiento)
 VALUES (@Username, @Password, 1, 1, @Nombre, @Apellido, @id_tipo_documento, @documento_nro, @mail, @telefono, @calle, @calle_nro, @piso, @dpto, @fecha_nacimiento)
 END;
 
END;

GO
CREATE PROCEDURE AEFI.crear_usuario_por_rol

 @ID_Rol NUMERIC(18,0),
 @ID_Usuario NUMERIC(18,0)

AS
BEGIN
 IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario_Por_Rol u WHERE ID_Rol = @ID_Rol AND ID_Usuario=@ID_Usuario )
 BEGIN
 INSERT INTO AEFI.TL_Usuario_Por_Rol(ID_Rol, ID_Usuario)
 VALUES (@ID_Rol, @ID_Usuario)
 END;

END;


GO
CREATE PROCEDURE AEFI.crear_usuario_por_hotel

 @ID_Rol NUMERIC(18,0),
 @ID_Usuario NUMERIC(18,0),
 @ID_Hotel NUMERIC(18,0)

AS
 BEGIN
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario_Por_Hotel u WHERE ID_Rol = @ID_Rol AND ID_Usuario=@ID_Usuario AND ID_Hotel = @ID_Hotel )
	BEGIN
	INSERT INTO AEFI.TL_Usuario_Por_Hotel(ID_Rol, ID_Usuario, ID_Hotel)
	VALUES (@ID_Rol, @ID_Usuario, @ID_Hotel)
	END;

END;

/*GO

CREATE FUNCTION AEFI.calcular_consumibles
 (@ID_Estadia NUMERIC(18,0))
 RETURNS NUMERIC(18, 2)
 AS
 BEGIN
	declare @RESULTADO NUMERIC(18,2)
	set @RESULTADO = (SELECT SUM(c.Precio) FROM AEFI.TL_Consumible_Por_Estadia cpe, AEFI.TL_Consumible c
						WHERE cpe.ID_Estadia = @ID_Estadia
						AND c.ID_Consumible = cpe.ID_Consumible
						)
	RETURN @RESULTADO
 END;*/
 
/* GO
 CREATE FUNCTION AEFI.calcular_costo_habitacion
 (@ID_Estadia NUMERIC(18,0))
 RETURNS NUMERIC(18, 2)
 AS
 BEGIN
	declare @RESULTADO NUMERIC(18,2)
	set @RESULTADO = (SELECT DISTINCT m.Habitacion_Tipo_Porcentual * m.Regimen_Precio
						FROM gd_esquema.Maestra m, AEFI.TL_Estadia e
						WHERE e.ID_Estadia = @ID_Estadia 
						AND m.Reserva_Codigo = e.ID_Reserva
						AND m.Habitacion_Tipo_Porcentual IS NOT NULL
						AND m.Regimen_Precio IS NOT NULL
						)
	RETURN @RESULTADO
	END;
	*/

/*GO
CREATE PROCEDURE AEFI.calcular_monto
(@ID_Estadia NUMERIC(18,0)) 
AS
BEGIN

			INSERT INTO AEFI.TL_Estadia(Monto)
			VALUES (AEFI.calcular_consumibles(@ID_Estadia) + AEFI.calcular_costo_habitacion(@ID_Estadia))
END;
	*/
GO
CREATE PROCEDURE AEFI.insertar_factura
	@forma_pago NVARCHAR(50),
	@fecha DATETIME,
	@id_factura NUMERIC(18,0) OUTPUT,
	@id_reserva NUMERIC(18,0)
AS
BEGIN	
	INSERT INTO AEFI.TL_Factura (Numero, Fecha, Total, ID_FormaDePago, ID_Cliente)
	VALUES ((
		SELECT MAX(Numero) + 1
		FROM AEFI.TL_Factura), @fecha, 0, (
			SELECT ID_FormaDePago
			FROM AEFI.TL_FormaDePago
			WHERE descripcion = @forma_pago), 
			(SELECT ID_Cliente
			FROM AEFI.TL_Reserva
			WHERE ID_Reserva = @id_reserva));
	SET @id_factura = (
		SELECT MAX(ID_Factura)
		FROM AEFI.TL_Factura);
		
	UPDATE AEFI.TL_Estadia
	SET Estado = 0;
		
END;

GO
CREATE PROCEDURE AEFI.insertar_item_precio_estadia
	@id_factura NUMERIC(18,0),
	@id_estadia NUMERIC(18,0),
	@id_regimen NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Estadia)
	VALUES (@id_factura, (
		SELECT Precio_Base
		FROM AEFI.TL_Regimen reg
		WHERE reg.ID_Regimen = @id_regimen), 1, @id_estadia);
	UPDATE AEFI.TL_Factura
	SET Total = Total + (SELECT Precio_Base FROM AEFI.TL_Regimen WHERE ID_Regimen = @id_regimen)
	WHERE ID_Factura = @id_factura;

	UPDATE AEFI.TL_Estadia
	SET Estado = 0
	WHERE ID_Estadia = @id_estadia
END;

GO
CREATE PROCEDURE AEFI.insertar_item_consumible
	@id_factura NUMERIC(18,0),
	@id_consumible NUMERIC(18,0),
	@id_regimen NUMERIC(18,0),
	@id_estadia NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Consumible)
	VALUES (@id_factura, (
		SELECT Precio
		FROM AEFI.TL_Consumible
		WHERE ID_Consumible = @id_consumible), (SELECT COUNT(*) FROM AEFI.TL_Consumible_Por_Estadia cpe
												WHERE cpe.ID_Estadia = @id_estadia AND cpe.ID_Consumible = @id_consumible
												group by cpe.ID_Consumible) , @id_consumible);
	UPDATE AEFI.TL_Factura
	SET Total = Total + (SELECT Precio_Base FROM AEFI.TL_Regimen WHERE ID_Regimen = @id_regimen)
	WHERE ID_Factura = @id_factura;
END;

GO
CREATE PROCEDURE AEFI.insertar_Registro_Pago_Sin_Tarjeta
	@id_factura NUMERIC(18,0),
	@fecha DATETIME
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Registro_Pago (ID_Factura, Fecha)
	VALUES (@id_factura, @fecha);
	
END;


GO
CREATE PROCEDURE AEFI.insertar_Registro_Pago_Con_Tarjeta
	@id_factura NUMERIC(18,0),
	@fecha DATETIME,
	@id_tarjeta NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Registro_Pago (ID_Factura, Fecha, ID_Tarjeta)
	VALUES (@id_factura, @fecha, @id_tarjeta);
	
END;

GO
CREATE PROCEDURE AEFI.insertar_nueva_Tarjeta
	@numero NUMERIC(18,0),
	@fecha DATETIME,
	@id_tarjeta NUMERIC(18,0)
	
AS
BEGIN	

IF NOT EXISTS (SELECT * FROM AEFI.TL_Tarjeta t WHERE t.Numero = @numero)
 BEGIN
	INSERT INTO AEFI.TL_Tarjeta (Numero, Fecha_vto)
	VALUES (@numero, @fecha);
	
	SET @id_tarjeta = (
		SELECT MAX(ID_Tarjeta)
		FROM AEFI.TL_ID_Tarjeta);
	
	END;

END;

/*FIN DE SP*/
