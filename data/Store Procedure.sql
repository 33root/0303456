GO

CREATE PROCEDURE AEFI.crear_Hotel

		@ID_Hotel nvarchar(10),
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono numeric(18,0),
		@Calle nvarchar(255),
		@Cantidad_Estrellas numeric(18,0),
		@Ciudad nvarchar(255),
		@Pais nvarchar(255),
		/*@Fecha_Creacion datetime,*/
		@NroCalle numeric(18,0),
		@Recarga_Estrellas nvarchar(50)

AS
BEGIN
		IF NOT EXISTS (SELECT * FROM AEFI.TL_Hotel h WHERE Nombre = @Nombre AND Nro_Calle = @NroCalle)
	BEGIN
			INSERT INTO AEFI.TL_Hotel(Nombre, Mail, Telefono, Calle, Cantidad_Estrellas, Ciudad, Pais,/* Fecha_Creacion,*/ Nro_Calle, Recarga_Estrellas)
			VALUES (@Nombre, @Mail, @Telefono, @Calle, @Cantidad_Estrellas, @Ciudad, @Pais,/* @Fecha_Creacion,*/ @NroCalle, @Recarga_Estrellas)
	END;

END;


GO

CREATE PROCEDURE AEFI.actualizar_Hotel

		@ID_Hotel numeric(18,0),
		@Nombre nvarchar(255),
		@Mail nvarchar(60),
		@Telefono int,
		@Calle nvarchar(255),
		@Cantidad_Estrellas numeric(18,0),
		@Recarga_Estrellas numeric(18,0),
		@Ciudad nvarchar(255),
		@Pais nvarchar(255),
		/*@Fecha_Creacion datetime,*/
		@NroCalle numeric(18,0)

AS
BEGIN
	
	BEGIN
    
    UPDATE AEFI.TL_Hotel
	SET Nombre =@Nombre, Mail = @Mail, Telefono = @Telefono, Calle = @Calle, Cantidad_Estrellas = @Cantidad_Estrellas, Ciudad = @Ciudad, Pais = @Pais, /*Fecha_Creacion = @Fecha_Creacion,*/ Nro_Calle = @NroCalle
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