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