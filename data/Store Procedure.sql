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
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Hotel h WHERE Nombre = @Nombre AND Mail = @Mail)
	BEGIN
			INSERT INTO AEFI.TL_Hotel(Nombre, Mail, Telefono, Calle, Cantidad_Estrellas, Ciudad, Pais, Fecha_Creacion, Nro_Calle, Recarga_Estrellas, Estado)
			VALUES (@Nombre, @Mail, @Telefono, @Calle, @Cantidad_Estrellas, @Ciudad, @Pais, @Fecha_Creacion, @NroCalle, @Recarga_Estrellas, 'Habilitado')
			
			INSERT INTO AEFI.TL_Usuario_Por_Hotel(ID_Hotel, ID_Usuario, ID_Rol)
			Select h.ID_Hotel, 1, 1 FROM AEFI.TL_Hotel h Where @Nombre = h.Nombre AND @Mail = h.Mail
			
			INSERT INTO AEFI.TL_Usuario_Por_Hotel(ID_Hotel, ID_Usuario, ID_Rol)
			Select h.ID_Hotel, 1, 1 FROM AEFI.TL_Hotel h Where @Nombre = h.Nombre AND @Mail = h.Mail
			
			INSERT INTO AEFI.TL_Usuario_Por_Hotel(ID_Hotel, ID_Usuario, ID_Rol)
			Select h.ID_Hotel, 1, 1 FROM AEFI.TL_Hotel h Where @Nombre = h.Nombre AND @Mail = h.Mail
	
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
		@Fecha_Creacion datetime,
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
CREATE PROCEDURE AEFI.baja_Hotel

		@ID_Hotel numeric(18,0),
		@Fecha_Inicio datetime,
		@Fecha_Fin datetime,
		@Descripcion varchar(255)

AS


BEGIN

IF NOT EXISTS (Select * FROM AEFI.TL_Hotel h WHERE h.Estado = 'Deshabilitado' AND h.ID_Hotel = @ID_Hotel)
	Begin

	IF (NOT EXISTS (SELECT * FROM AEFI.TL_Reserva re, AEFI.TL_Habitacion ha WHERE ha.ID_Hotel = @ID_Hotel AND re.ID_Habitacion = ha.ID_Habitacion AND re.Fecha_Desde BETWEEN @Fecha_Inicio AND @Fecha_Fin AND @ID_Hotel = ha.ID_Hotel) AND NOT EXISTS 
	(SELECT * 
	FROM AEFI.TL_Estadia es, AEFI.TL_Reserva re, AEFI.TL_Habitacion ha 
	WHERE es.ID_Reserva = re.ID_Reserva
	AND re.ID_Habitacion = ha.ID_Habitacion
	AND ha.ID_Hotel = @ID_Hotel
	AND es.Fecha_Inicio BETWEEN @Fecha_Inicio AND @Fecha_Fin))
	BEGIN 
	INSERT INTO AEFI.TL_Baja_Hotel (Fecha_Inicio, Fecha_Fin, Descripcion, ID_Hotel)
	VALUES (@Fecha_Inicio, @Fecha_Fin, @Descripcion, @ID_Hotel)
	
	UPDATE AEFI.TL_Hotel
	SET Estado = 'Deshabilitado'
	WHERE @ID_Hotel = ID_Hotel
END
ELSE

RAISERROR(61111, 1, 1)
END
ELSE 

RAISERROR (61112 , 1, 1)	
END;
	
	
GO	
	
CREATE PROCEDURE AEFI.crear_Habitacion


		@ID_Hotel nvarchar(10),
		@ID_Habitacion nvarchar(10),
		@Numero nvarchar(50),
		@Piso nvarchar(50),
		@Vista nvarchar (50),
		@Tipo_Habitacion nvarchar(50)
		

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Habitacion h WHERE Numero = @Numero)	
	
	BEGIN
			INSERT INTO AEFI.TL_Habitacion(ID_Hotel, Numero, Piso, Vista, Disponible, Estado, ID_Tipo_Habitacion)
			VALUES (@ID_Hotel, @Numero, @Piso, @Vista, 'Si', 'Habilitado',(SELECT ID_Tipo_Habitacion 
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
		@Tipo_Habitacion nvarchar(50),
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
	
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Mail = @Mail)
		INSERT INTO AEFI.TL_Cliente
		VALUES (@Nombre, @Apellido, (
			SELECT ID_Tipo_Documento
			FROM AEFI.TL_Tipo_Documento
			WHERE Descripcion = @ID_Tipo_Documento), 
			@Documento_Numero,@Mail, @Calle, @Calle_Nro, @Piso, @Dpto, @Telefono, @Fecha_Nacimiento,@PaisOrigen, @Localidad, @PaisOrigen);
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
	/*IF @localidad IS NOT NULL
	BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Localidad = @Localidad )
			INSERT INTO AEFI.TL_Cliente(Localidad)
			VALUES (@Localidad);
	END;

	IF NOT EXISTS (SELECT * FROM AEFI.TL_Cliente WHERE Calle = @Calle
		AND Calle_Nro = @Calle_Nro AND Piso = @Piso AND Dpto = @Dpto )
	BEGIN
		IF @Localidad IS NOT NULL
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto, Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto,
			(
				SELECT Localidad
				FROM AEFI.TL_Cliente
				WHERE Localidad = @localidad )
			);
		ELSE
			INSERT INTO AEFI.TL_Cliente(Calle, Calle_Nro, Piso, Dpto,  Localidad)
			VALUES (@Calle, @Calle_Nro, @Piso, @Dpto, NULL);
	END;*/
	IF EXISTS(SELECT ID_Cliente FROM AEFI.TL_Cliente WHERE ID_Cliente = @ID_Cliente)
	BEGIN
	UPDATE AEFI.TL_Cliente
	SET ID_Tipo_Documento = (
		SELECT ID_Tipo_Documento
		FROM AEFI.TL_Tipo_Documento
		WHERE Descripcion = @ID_Tipo_Documento), Documento_Nro = @Documento_Numero, Mail = @Mail, Telefono = @Telefono, Fecha_Nacimiento = @Fecha_Nacimiento, Calle = @Calle, Nombre = @Nombre, Apellido = @Apellido, Calle_Nro = @Calle_Nro, Localidad = @Localidad
	WHERE ID_Cliente = @ID_Cliente
	END
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

GO

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
 END;
 
GO
 CREATE FUNCTION AEFI.calcular_costo_habitacion --diario
 (@ID_Estadia NUMERIC(18,0))
 RETURNS NUMERIC(18, 2)
 AS
 BEGIN
	declare @RESULTADO NUMERIC(18,2)
	set @RESULTADO = (SELECT  th.Porcentual * r.Precio_Base
						FROM AEFI.TL_Tipo_Habitacion th, AEFI.TL_Regimen r, AEFI.TL_Estadia e, AEFI.TL_Reserva re, AEFI.TL_Habitacion h
						WHERE e.ID_Estadia = @ID_Estadia
						AND e.ID_Reserva = re.ID_Reserva
						AND re.ID_Regimen = r.ID_regimen
						AND re.ID_Habitacion = h.ID_Habitacion
						AND h.ID_Tipo_Habitacion = th.ID_Tipo_Habitacion
						)
	RETURN @RESULTADO
	END;


GO
CREATE PROCEDURE AEFI.insertar_factura
	@fecha DATETIME,
	@id_factura NUMERIC(18,0) OUTPUT,
	@id_reserva NUMERIC(18,0)
AS
BEGIN	
	SET IDENTITY_INSERT [AEFI].[TL_Factura] ON
	INSERT INTO AEFI.TL_Factura (ID_Factura, Fecha, Total, ID_Cliente)
	VALUES ((
		SELECT MAX(ID_Factura) + 1
		FROM AEFI.TL_Factura), @fecha, 0, 
			(SELECT ID_Cliente
			FROM AEFI.TL_Reserva
			WHERE ID_Reserva = @id_reserva));
			SET IDENTITY_INSERT [AEFI].[TL_Factura] OFF
	SET @id_factura = (
		SELECT MAX(ID_Factura)
		FROM AEFI.TL_Factura);
		
END;

GO
CREATE PROCEDURE AEFI.insertar_item_precio_estadia
	@id_factura NUMERIC(18,0),
	@id_estadia NUMERIC(18,0),
	@id_regimen NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Estadia, Descripcion)
	VALUES (@id_factura, (AEFI.calcular_costo_habitacion(@id_estadia)* --precio base del regimen
			(SELECT DATEDIFF(DAY, GETDATE(), e.fecha_inicio) FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia)*--dias alojados
			(SELECT r.Cantidad_Huespedes FROM AEFI.TL_Reserva r, AEFI.TL_Estadia e WHERE r.ID_Reserva = e.ID_Reserva AND e.ID_Estadia = @id_estadia)--huespedes alojados
			*(SELECT (ho.cantidad_estrellas * ho.recarga_estrellas) from AEFI.TL_hotel ho, AEFI.TL_Habitacion ha, AEFI.TL_Reserva re, AEFI.TL_Estadia es  WHERE re.Id_reserva = es.ID_Reserva AND re.ID_Habitacion = ha.ID_Habitacion AND ho.ID_Hotel = ha.ID_Hotel AND es.ID_Estadia = @id_estadia)--recarga estrellas
			), 1, @id_estadia, 'Costo Estadía: '++ (SELECT CONVERT(VARCHAR(55), e.fecha_inicio, 104) FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia)++' a '++ CONVERT(VARCHAR(255),GETDATE(), 104) );
	UPDATE AEFI.TL_Factura
	SET Total = Total + (AEFI.calcular_costo_habitacion(@id_estadia)* --precio base del regimen
			(SELECT DATEDIFF(DAY, GETDATE(), e.fecha_inicio) FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia)*--dias alojados
			(SELECT r.Cantidad_Huespedes FROM AEFI.TL_Reserva r, AEFI.TL_Estadia e WHERE r.ID_Reserva = e.ID_Reserva AND e.ID_Estadia = @id_estadia)--huespedes alojados
			*(SELECT (ho.cantidad_estrellas * ho.recarga_estrellas) from AEFI.TL_hotel ho, AEFI.TL_Habitacion ha, AEFI.TL_Reserva re, AEFI.TL_Estadia es  WHERE re.Id_reserva = es.ID_Reserva AND re.ID_Habitacion = ha.ID_Habitacion AND ho.ID_Hotel = ha.ID_Hotel AND es.ID_Estadia = @id_estadia))--recarga estrellas
	WHERE ID_Factura = @id_factura;

	UPDATE AEFI.TL_Estadia
	SET Estado = 0
	WHERE ID_Estadia = @id_estadia
	
	
	
END;


GO 
CREATE PROCEDURE AEFI.calcular_costo_porDia
@id_habitacion NUMERIC(18,0),
@cantidad_noches NUMERIC(18,0),
@id_regimen NUMERIC(18,0),
@id_tipo_habitacion NUMERIC(18,0),
@costo NUMERIC(18,2) OUTPUT



AS 
BEGIN
	set @costo =( SELECT (ho.cantidad_estrellas * ho.recarga_estrellas + reg.Precio_Base * t.Porcentual * @cantidad_noches )
	from AEFI.TL_hotel ho, AEFI.TL_Habitacion ha, AEFI.TL_Regimen reg, AEFI.TL_Tipo_Habitacion t
	WHERE ha.ID_Habitacion = @id_habitacion 
	AND ha.ID_Hotel = ho.ID_Hotel --recarga estrellas
	AND reg.ID_Regimen = @id_regimen 
	AND t.ID_Tipo_Habitacion = @id_tipo_habitacion)
	
	return @costo
	
END;


GO
CREATE PROCEDURE AEFI.insertar_item_precio_diasNoAlojados
	@id_factura NUMERIC(18,0),
	@id_estadia NUMERIC(18,0),
	@id_regimen NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Estadia, Descripcion)
	VALUES (@id_factura, ((
		SELECT Precio_Base
		FROM AEFI.TL_Regimen reg
		WHERE reg.ID_Regimen = @id_regimen)*
		(SELECT DATEDIFF(DAY, DATEADD(DAY, e.Cantidad_Noches, e.Fecha_Inicio), GETDATE()) 
		FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia))
		, 1, @id_estadia, 'Dias no alojados: '++ CONVERT(VARCHAR(55), GETDATE(), 104) ++' a '++ (SELECT CONVERT(VARCHAR(55), DATEADD(DAY, e.Cantidad_Noches, e.Fecha_Inicio), 104) FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia));
	UPDATE AEFI.TL_Factura
	SET Total = Total + ((
		SELECT Precio_Base
		FROM AEFI.TL_Regimen reg
		WHERE reg.ID_Regimen = @id_regimen)*
		(SELECT DATEDIFF(DAY, DATEADD(DAY, e.Cantidad_Noches, e.Fecha_Inicio), GETDATE()) 
		FROM AEFI.TL_Estadia e WHERE e.ID_Estadia = @id_estadia))
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
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Consumible, Descripcion)
	VALUES (@id_factura,(
		SELECT Precio
		FROM AEFI.TL_Consumible
		WHERE ID_Consumible = @id_consumible), (SELECT COUNT(*) FROM AEFI.TL_Consumible_Por_Estadia cpe
												WHERE cpe.ID_Estadia = @id_estadia AND cpe.ID_Consumible = @id_consumible
												group by cpe.ID_Consumible) , @id_consumible, (SELECT Descripcion FROM AEFI.TL_Consumible WHERE ID_Consumible = @id_consumible));
	
	
	IF (@id_regimen = 4) 
	BEGIN
	INSERT INTO AEFI.TL_Item_Por_Factura (ID_Factura, Monto, Cantidad, ID_Consumible, Descripcion)
	VALUES (@id_factura,(
		SELECT Precio
		FROM AEFI.TL_Consumible
		WHERE ID_Consumible = @id_consumible)*(-1), (SELECT COUNT(*) FROM AEFI.TL_Consumible_Por_Estadia cpe
												WHERE cpe.ID_Estadia = @id_estadia AND cpe.ID_Consumible = @id_consumible
												group by cpe.ID_Consumible) , @id_consumible, 'Descuento por Regimen All Inclusive');
	END
	
	
	
	
END;


GO
CREATE PROCEDURE AEFI.insertar_Registro_Pago_Sin_Tarjeta
	@id_factura NUMERIC(18,0),
	@id_cliente NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Registro_Pago (ID_Factura, Fecha, ID_Cliente, FormaDePago)
	VALUES (@id_factura, GETDATE(), @id_cliente, 'Efectivo');
	
END;

GO
CREATE PROCEDURE AEFI.insertar_Registro_Pago_Con_Tarjeta
	@id_factura NUMERIC(18,0),
	@numeroTarjeta NUMERIC(18,0),
	@id_cliente NUMERIC(18,0)
	
AS
BEGIN	
	INSERT INTO AEFI.TL_Registro_Pago (ID_Factura, Fecha, ID_Tarjeta, ID_Cliente, FormaDePago)
	VALUES (@id_factura, GETDATE(), (SELECT ID_Tarjeta FROM AEFI.TL_Tarjeta WHERE Numero = @numeroTarjeta), @id_cliente, 'Tarjeta de Crédito');
	
END;


GO
CREATE PROCEDURE AEFI.insertar_nueva_Tarjeta
	@numero NUMERIC(18,0),
	@fecha DATETIME,
	@id_Cliente NUMERIC(18,0)
	
AS
BEGIN	

IF NOT EXISTS (SELECT * FROM AEFI.TL_Tarjeta t WHERE t.Numero = @numero)
 BEGIN
 
 SET IDENTITY_INSERT AEFI.TL_Tarjeta ON
	INSERT INTO AEFI.TL_Tarjeta (Numero, Fecha_vto, ID_Tarjeta, ID_Cliente)
	VALUES (@numero, @fecha,((SELECT COUNT(*) FROM AEFI.TL_Tarjeta)+1), @id_Cliente);
	
SET IDENTITY_INSERT AEFI.TL_Tarjeta OFF
	
	
	END;

END;


GO
CREATE PROCEDURE AEFI.insertar_Reserva
  @Fecha_Desde datetime,
  @Cantidad_Huespedes NUMERIC(18,0),
  @Cantidad_Noches NUMERIC(18,0),
  @ID_Regimen NUMERIC(18,0),
  @ID_Habitacion NUMERIC(18,0),
  @Estado varchar(255),
  @ID_Cliente NUMERIC(18,0)

AS
BEGIN
 IF NOT EXISTS (SELECT * FROM AEFI.TL_Reserva WHERE Fecha_Reserva = GETDATE() AND Fecha_Desde = @Fecha_Desde AND Cantidad_Huespedes = @Cantidad_Huespedes AND Cantidad_Noches = @Cantidad_Noches AND ID_Regimen = @ID_Regimen AND ID_Habitacion = @ID_Habitacion AND Estado = @Estado AND ID_Cliente = @ID_Cliente)
 BEGIN
 INSERT INTO AEFI.TL_Reserva(Fecha_Reserva,Fecha_Desde,Cantidad_Huespedes,Cantidad_Noches,ID_Regimen,ID_Habitacion,Estado,ID_Cliente)
 VALUES (GETDATE(), @Fecha_Desde, @Cantidad_Huespedes, @Cantidad_Noches, @ID_Regimen, @ID_Habitacion, @Estado, @ID_Cliente)
 END;
 
 UPDATE AEFI.TL_Habitacion SET Disponible = 'No' WHERE ID_Habitacion = @ID_Habitacion
 
END;

/*CREATE PROCEDURE AEFI.registrarEstadia

		@ID_Reserva numeric(18,0)
		
AS

begin transaction

IF(GETDATE() = (Select Fecha_Desde from AEFI.TL_Reserva r where r.ID_Reserva = @id_reserva))

begin 

/*Se deberia agregar la cantidad de huespedes que realmente se hospedan?? */

INSERT INTO AEFI.TL_Estadia (Estado, Fecha_Inicio, Cantidad_Noches)
SELECT '1', GETDATE(), r.Cantidad_Noches 
from AEFI.TL_Reserva r
where r.ID_Reserva = @ID_Reserva


end

ELSE 

	begin transaction
	
	INSERT INTO [AEFI].[TL_Cancelacion](Motivo, Fecha, ID_Usuario)
	Select 'La fecha de reserva expiro', GETDATE(), (Select id_Cliente FROM [AEFI].[TL_Reserva] r 
														where r.ID_Cliente = @ID_Reserva)
														
	Update [AEFI].[TL_Habitacion]
	Set Disponible = 'Si'
	
		/*Hay que ver si cuando se cancela la reserva se elimina el registro de reserva y solo queda el de
		cancelacion (tendria que haber una fk de reserva a cancelacion? o como esta esta bien?) 
		- Las reservas no tienen que cambiar la disponibilidad de las habitacions a "NO"??
		*/
	
	
	
	
	end
end
*/

		
GO		
CREATE PROCEDURE AEFI.top5_consumiblesFacturados
	@ano int,
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 ho.ID_Hotel, ho.Nombre, ho.Calle,(SELECT SUM(it1.Cantidad) from AEFI.TL_Item_Por_Factura  it1 WHERE it1.ID_Factura = it.ID_Factura)  AS CANTIDAD
		FROM AEFI.TL_Hotel ho, AEFI.TL_Item_Por_Factura it, AEFI.TL_Consumible_Por_Estadia cpe, AEFI.TL_Habitacion ha, AEFI.TL_Reserva re, AEFI.TL_Factura fa, AEFI.TL_Estadia es
		WHERE cpe.ID_Consumible = it.ID_Consumible
		AND re.ID_Cliente = fa.ID_Cliente
		AND es.ID_Reserva = re.ID_Reserva
		AND cpe.ID_Estadia = es.ID_Estadia
		AND it.ID_Factura = fa.ID_Factura
		AND re.ID_Habitacion = ha.ID_Habitacion
		AND ha.ID_Hotel = ho.ID_Hotel
		AND YEAR(fa.Fecha) = @ano
		AND MONTH(fa.Fecha) BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY ho.ID_Hotel, ho.Nombre, ho.Calle, it.ID_Consumible, it.ID_Factura
		ORDER BY CANTIDAD DESC
END;


GO		
CREATE PROCEDURE AEFI.top5_reservasCanceladas
	@ano int,
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 ho.ID_Hotel, ho.Nombre, ho.Calle, (SELECT COUNT(DISTINCT id_cancelacion) from AEFI.TL_Cancelacion c1, AEFI.TL_Hotel ho1, AEFI.TL_Reserva r1, AEFI.TL_Habitacion ha1
		WHERE ho1.ID_Hotel = ha1.ID_Hotel
		AND r1.ID_Habitacion = ha1.ID_Habitacion
		AND r1.ID_Reserva = c1.ID_Reserva
		AND ho1.ID_Hotel = ho.ID_Hotel
		GROUP BY ho1.ID_Hotel) AS CANTIDAD
		FROM AEFI.TL_Hotel ho, AEFI.TL_Cancelacion c, AEFI.TL_Reserva r, AEFI.TL_Habitacion ha
		WHERE ho.ID_Hotel = ha.ID_Hotel
		AND r.ID_Habitacion = ha.ID_Habitacion
		AND c.ID_Reserva = r.ID_Reserva
		AND YEAR(c.Fecha) = @ano
		AND MONTH(c.Fecha) BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY ho.ID_Hotel, ho.Nombre, ho.Calle
		ORDER BY CANTIDAD DESC
END;


GO		
CREATE PROCEDURE AEFI.top5_diasFueraDeServicio
	@ano int,
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 ho.ID_Hotel, ho.Nombre, ho.Calle, (SELECT SUM(DATEDIFF(DAY, fecha_fin, fecha_inicio)) from AEFI.TL_Baja_Hotel ba1 where ba1.ID_Hotel = ho.ID_Hotel) AS CANTIDAD
		FROM AEFI.TL_Hotel ho,AEFI.TL_Baja_Hotel ba
		WHERE ho.ID_Hotel = ba.ID_Hotel
		AND YEAR(ba.Fecha_Inicio) = @ano
		AND MONTH(ba.Fecha_Inicio) BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY ho.ID_Hotel, ho.Nombre, ho.Calle, ba.ID_Hotel
		ORDER BY CANTIDAD DESC
END;


GO		
CREATE PROCEDURE AEFI.top5_diasOcupados
	@ano int,
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 ho.ID_Hotel, ho.Nombre, ho.Calle, ha.Numero, (SELECT SUM(e1.Cantidad_Noches) from AEFI.TL_Estadia e1, AEFI.TL_Reserva r1, AEFI.TL_Habitacion ha1, AEFI.TL_Hotel ho1 
																		WHERE ho1.ID_Hotel = ha1.ID_Hotel
																		AND r1.ID_Habitacion = ha1.ID_Habitacion
																		AND e1.ID_Reserva = r1.ID_Reserva
																		and e1.ID_Estadia = e.ID_Estadia
																		group by e1.ID_Estadia) AS CANTIDAD
		FROM AEFI.TL_Hotel ho, AEFI.TL_Habitacion ha, AEFI.TL_Estadia e, AEFI.TL_Reserva re
		WHERE ho.ID_Hotel = ha.ID_Hotel
		AND re.ID_Habitacion = ha.ID_Habitacion
		AND e.ID_Reserva = re.ID_Reserva
		AND YEAR(e.Fecha_Inicio) = @ano
		AND MONTH(e.Fecha_Inicio) BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY ho.ID_Hotel, ho.Nombre, ho.Calle, ha.Numero, e.ID_Estadia
		ORDER BY CANTIDAD DESC
END;

GO		
CREATE PROCEDURE AEFI.top5_vecesReservada
	@ano int,	
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 ho.ID_Hotel, ho.Nombre, ho.Calle, ha.Numero, (SELECT COUNT(DISTINCT e1.ID_Estadia) from AEFI.TL_Estadia e1, AEFI.TL_Reserva r1, AEFI.TL_Habitacion ha1, AEFI.TL_Hotel ho1 
																		WHERE ho1.ID_Hotel = ha1.ID_Hotel
																		AND r1.ID_Habitacion = ha1.ID_Habitacion
																		AND e1.ID_Reserva = r1.ID_Reserva
																		and ho1.ID_Hotel = ho.ID_Hotel
																		group by ho1.ID_Hotel) AS CANTIDAD
		FROM AEFI.TL_Hotel ho, AEFI.TL_Habitacion ha, AEFI.TL_Estadia e, AEFI.TL_Reserva re
		WHERE ho.ID_Hotel = ha.ID_Hotel
		AND re.ID_Habitacion = ha.ID_Habitacion
		AND e.ID_Reserva = re.ID_Reserva
		AND YEAR(e.Fecha_Inicio) = @ano
		AND MONTH(e.Fecha_Inicio) BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY ho.ID_Hotel, ho.Nombre, ho.Calle, ha.Numero
		ORDER BY CANTIDAD DESC
END;

/*Cliente con mayor cantidad de puntos, donde cada $10 en estadías vale 1 puntos y cada $5 de consumibles es 1 punto, 
de la sumatoria de todas las facturaciones que haya tenido dentro de un periodo independientemente del Hotel. 
Tener en cuenta que la facturación siempre es a quien haya realizado la reserva.*/


GO		
CREATE PROCEDURE AEFI.top5_puntosCliente
	@ano int,	
	@inicio_trimestre int, 
	@fin_trimestre int
AS
BEGIN
	SELECT DISTINCT TOP 5 c.ID_Cliente, c.nombre, c.apellido, (SELECT SUM(Puntos) from AEFI.TL_Puntos_Por_Factura p1 WHERE p1.ID_Cliente = p.ID_Cliente)AS Puntos
	FROM AEFI.TL_Cliente c, AEFI.TL_Puntos_Por_Factura p
	WHERE p.ID_Cliente = c.ID_Cliente
	AND YEAR(p.Fecha) = @ano
	AND MONTH(p.Fecha) BETWEEN @inicio_trimestre AND @fin_trimestre
	GROUP BY c.ID_Cliente,p.ID_Cliente, c.Nombre, c.Apellido
	
END;

GO
CREATE PROCEDURE AEFI.cancelar_Reserva
	@ID_Reserva NUMERIC(18,0),
	@Motivo varchar(255),
	@ID_Usuario NUMERIC(18,0)

AS
BEGIN
	UPDATE AEFI.TL_Reserva
	SET Estado = 'Cancelada por Usuario'
	WHERE ID_Reserva = @ID_Reserva
	
	INSERT INTO AEFI.TL_Cancelacion(Motivo, ID_Reserva, Fecha, ID_Usuario)
	VALUES (@Motivo,@ID_Reserva,GETDATE(),@ID_Usuario);
		
END;


GO 
CREATE PROCEDURE AEFI.generarIngresoEstadia
@idReserva NUMERIC(18,0),
@idFactura NUMERIC(18,0),
@idUsuario NUMERIC(18,0)



AS 
BEGIN
IF NOT EXISTS (SELECT ID_Estadia FROM AEFI.TL_Estadia e WHERE e.ID_Reserva = @idReserva)
BEGIN
	INSERT INTO AEFI.TL_Estadia
	SELECT 1, GETDATE(),r.cantidad_noches, @idReserva, @idFactura
	FROM AEFI.TL_Reserva r
	WHERE ID_Reserva = @idReserva
END
	
	INSERT INTO AEFI.TL_Registro_Evento
	SELECT (SELECT MAX(ID_Estadia) FROM AEFI.TL_Estadia), 'Ingreso', @idUsuario, GETDATE()
	FROM AEFI.TL_Reserva r
	WHERE ID_Reserva = @idReserva
	
	UPDATE AEFI.TL_Reserva
	SET Estado = 'Efectivizada'
	WHERE ID_Reserva = @idReserva
	
END;

GO 
CREATE PROCEDURE AEFI.generarEgresoEstadia
@idReserva NUMERIC(18,0),
@idUsuario NUMERIC(18,0)



AS 
BEGIN
	UPDATE AEFI.TL_Estadia
	SET Estado =  0
	WHERE ID_Reserva = @idReserva
	
	
	INSERT INTO AEFI.TL_Registro_Evento
	SELECT (SELECT ID_Estadia FROM AEFI.TL_Estadia e WHERE e.ID_Reserva = r.ID_Reserva), 'Egreso', @idUsuario, GETDATE()
	FROM AEFI.TL_Reserva r
	WHERE ID_Reserva = @idReserva
END;


GO 
CREATE PROCEDURE AEFI.agregarConsumiblePorEstadia
@consumible NVARCHAR(55),
@idEstadia NUMERIC(18,0),
@cantidad NUMERIC(18,0)



AS 
BEGIN
	
	INSERT INTO AEFI.TL_Consumible_Por_Estadia
	VALUES ((SELECT ID_Consumible FROM AEFI.TL_Consumible WHERE Descripcion = @consumible), @cantidad, @idEstadia)
	
	
	END;
	
	GO 
CREATE PROCEDURE AEFI.quitarConsumiblePorEstadia
@idConsumiblePorEstadia NUMERIC(18,0)

AS 
BEGIN

DELETE FROM AEFI.TL_Consumible_Por_Estadia 
WHERE ID_Consumible_Por_Estadia = @idConsumiblePorEstadia
	
	
	END;
	
	
GO

CREATE PROCEDURE AEFI.eliminar_Hotel_Usuario
    @IdUser NUMERIC(18,0),
    @IDHotel NUMERIC(18,0),
    @IDRol NUMERIC(18,0)
		
AS
BEGIN
	IF EXISTS (SELECT * FROM AEFI.TL_Usuario_Por_Hotel WHERE ID_Hotel = @IDHotel AND ID_Usuario = @IdUser AND ID_Rol = @IDRol)
	BEGIN
		DELETE AEFI.TL_Usuario_Por_Hotel
		WHERE ID_Hotel = @IDHotel
		AND ID_Rol = @IDRol
		AND ID_Usuario = @IdUser
	END
END;

GO

CREATE PROCEDURE AEFI.insertar_Hotel_Usuario
    @IdUser NUMERIC(18,0),
    @IDHotel NUMERIC(18,0),
    @IDRol NUMERIC(18,0)
		
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario_Por_Hotel WHERE ID_Hotel = @IDHotel AND ID_Usuario = @IdUser AND ID_Rol = @IDRol)
	BEGIN
		INSERT INTO AEFI.TL_Usuario_Por_Hotel
		VALUES (@IDHotel, @IDRol, @IdUser);
	END
END;

GO

CREATE PROCEDURE AEFI.deshabilitarUsuario
    @IdUser NUMERIC(18,0)
AS
BEGIN
	IF EXISTS (SELECT * FROM AEFI.TL_Usuario WHERE ID_Usuario = @IdUser)
	BEGIN
		UPDATE AEFI.TL_Usuario
		SET Habilitado = 0
		WHERE ID_Usuario = @IdUser
		
	END
END;



GO
CREATE PROCEDURE AEFI.insertar_Rol_Usuario
@user NUMERIC(18,0),
@Descripcion NVARCHAR(55)

AS
BEGIN
		IF NOT EXISTS(SELECT upr.ID_Rol, upr.ID_Usuario FROM AEFI.TL_Usuario_Por_Rol upr, AEFI.TL_Rol r WHERE upr.ID_Usuario = @user AND r.ID_Rol = upr.ID_Rol AND r.Descripcion = @Descripcion)
		BEGIN
			INSERT INTO AEFI.TL_Usuario_Por_Rol
			VALUES ((SELECT ID_Rol FROM AEFI.TL_Rol WHERE Descripcion = @Descripcion), @user)
			
			END
END;


GO
CREATE PROCEDURE AEFI.quitar_Rol_Usuario
@user NUMERIC(18,0),
@Descripcion NVARCHAR(55)

AS
BEGIN
		IF EXISTS(SELECT upr.ID_Rol FROM AEFI.TL_Usuario_Por_Rol upr, AEFI.TL_Rol r WHERE upr.ID_Usuario = @user AND r.ID_Rol = upr.ID_Rol AND r.Descripcion = @Descripcion)
		BEGIN
			DELETE AEFI.TL_Usuario_Por_Rol
			WHERE ID_Usuario = @user AND ID_Rol = (SELECT ID_Rol FROM AEFI.TL_Rol WHERE Descripcion = @Descripcion);
			
			DELETE AEFI.TL_Usuario_Por_Hotel
			WHERE ID_Usuario = @user AND ID_Rol = (SELECT ID_Rol FROM AEFI.TL_Rol WHERE Descripcion = @Descripcion);
			
			END
END;

GO
CREATE PROCEDURE AEFI.modificar_nombre_rol
@ID_Rol NUMERIC(18,0),
@nombre NVARCHAR(55)
AS
BEGIN 
		UPDATE AEFI.TL_Rol
		SET Descripcion = @nombre
		WHERE ID_Rol = @ID_Rol
		
END;

GO 
CREATE PROCEDURE AEFI.cancelarReserva
@IDReserva NUMERIC(18,0)
AS 
BEGIN
	IF EXISTS (SELECT * FROM AEFI.TL_Reserva r WHERE r.Fecha_Desde < GETDATE() AND r.Estado = 'Correcta' AND r.ID_Reserva = @IDReserva)
	BEGIN
	UPDATE AEFI.TL_Reserva
	SET Estado = 'Cancelada por No-Show'
	WHERE ID_Reserva = @IDReserva
	END
END;

GO
CREATE PROCEDURE AEFI.modificar_Reserva
@Fecha_Desde datetime,
@Cantidad_Huespedes NUMERIC(18,0),
@Cantidad_Noches NUMERIC(18,0),
@ID_Regimen NUMERIC(18,0),
@ID_Habitacion NUMERIC(18,0),
@Estado varchar(255),
@ID_Cliente NUMERIC(18,0),
@ID_Reserva NUMERIC(18,0)
AS
BEGIN
	UPDATE AEFI.TL_Reserva
	SET Fecha_Desde = @Fecha_Desde, Cantidad_Huespedes = @Cantidad_Huespedes, Cantidad_Noches = @Cantidad_Noches, ID_Regimen = @ID_Regimen, ID_Habitacion = @ID_Habitacion, Estado = @Estado, Fecha_Reserva = GETDATE()
	WHERE ID_Reserva = @ID_Reserva
END;

GO
CREATE PROCEDURE AEFI.crear_Rol
@Nombre NVARCHAR(255)

AS 
BEGIN
	IF NOT EXISTS(SELECT * FROM AEFI.TL_Rol WHERE Descripcion = @Nombre)
	BEGIN
	INSERT INTO AEFI.TL_Rol
	VALUES (@Nombre, 0)
	
	INSERT INTO AEFI.TL_Usuario_Por_Rol
	VALUES((SELECT ID_Rol FROM AEFI.TL_Rol WHERE Descripcion = @Nombre), 1)
	
	END
	
END;