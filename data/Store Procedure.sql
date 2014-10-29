GO

CREATE PROCEDURE AEFI.crear_Hotel

		@ID_Hotel nvarchar(10),
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono int,
		@Calle nvarchar(255),
		@Cantidad_Estrellas int,
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

		@ID_Hotel int,
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono int,
		@Calle nvarchar(255),
		@Cantidad_Estrellas int,
		/*@Recarga_Estrellas int,*/
		@Ciudad nvarchar(255),
		@Pais nvarchar(255),
		@Fecha_Creacion datetime,
		@NroCalle numeric(18,0)

AS
BEGIN
	
	BEGIN
    
    UPDATE AEFI.TL_Hotel
	SET Nombre =@Nombre, Mail = @Mail, Telefono = @Telefono, Calle = @Calle, Cantidad_Estrellas = @Cantidad_Estrellas, Ciudad = @Ciudad, Pais = @Pais, Fecha_Creacion = @Fecha_Creacion, Nro_Calle = @NroCalle
	WHERE ID_Hotel = @ID_Hotel
						
	END;	
			
END;	
	
GO	
	
CREATE PROCEDURE AEFI.crear_Habitacion

		@Numero nvarchar (50),
		@Piso nvarchar (50),
		@Vista nvarchar (50),
		@Descripcion nvarchar(255),
		@Tipo_Habitacion nvarchar(255)
		

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Habitacion h WHERE Numero = @Numero)	
	
	BEGIN
			INSERT INTO AEFI.TL_Habitacion(Numero, Piso, Vista, Tipo_Comodidades, ID_Tipo_Habitacion)
			VALUES (@Numero, @Piso, @Vista, @Descripcion, (SELECT ID_Tipo_Habitacion 
	FROM AEFI.TL_Tipo_Habitacion th
	WHERE th.Descripcion = @Tipo_Habitacion))
	END;

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
		@telefono numeric(18,0),
		@calle nvarchar(255),
		@calle_nro numeric(18,0),
		@piso numeric(18,0),
		@dpto nvarchar(50),
		@mail nvarchar(255),
		@fecha_nacimiento datetime

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Usuario u WHERE Username = @Username )
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