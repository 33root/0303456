BEGIN TRANSACTION

INSERT INTO AEFI.TL_Cliente(Nombre,Apellido,ID_Tipo_Documento,Documento_Nro,Mail,Calle,Calle_Nro,Piso,Dpto,Fecha_Nacimiento,Nacionalidad,Localidad,PaisOrigen)
SELECT DISTINCT SUBSTRING(UPPER (m.Cliente_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cliente_Nombre), 2,10), SUBSTRING(UPPER (m.Cliente_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cliente_Apellido), 2,10) ,2, m.Cliente_Pasaporte_Nro, LOWER(m.Cliente_Mail), m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, m.Cliente_Fecha_Nac, m.Cliente_Nacionalidad,'CABA','Argentina' 
FROM gd_esquema.Maestra m
WHERE Cliente_Apellido IS NOT NULL AND Cliente_Nombre IS NOT NULL

INSERT INTO [AEFI].[TL_Hotel](Nombre, Calle, Nro_Calle,Ciudad,Cantidad_Estrellas,Recarga_Estrellas, Pais, Estado)
SELECT DISTINCT 'Hotel '+ Hotel_Calle, Hotel_Calle, Hotel_Nro_Calle, Hotel_Ciudad, Hotel_CantEstrella, Hotel_Recarga_Estrella, 'Argentina', 'Habilitado'
FROM gd_esquema.Maestra


/* Cargo todos los hoteles a todos los roles del usuario admin*/
INSERT INTO AEFI.TL_Usuario_Por_Hotel 
SELECT h.ID_Hotel, 1, r.ID_Rol
FROM AEFI.TL_Hotel h, AEFI.TL_Rol r

SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion ON
INSERT INTO AEFI.TL_Tipo_Habitacion(ID_Tipo_Habitacion, Descripcion, Porcentual)
SELECT DISTINCT m.Habitacion_Tipo_Codigo, m.Habitacion_Tipo_Descripcion, m.Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra m
SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion OFF


UPDATE AEFI.TL_Tipo_Habitacion 
SET Cantidad_Huespedes_Total = 2
WHERE Descripcion = 'Base Doble' 

UPDATE AEFI.TL_Tipo_Habitacion
SET Cantidad_Huespedes_Total = 5
WHERE Descripcion = 'King'

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
INSERT INTO [AEFI].[TL_Reserva] (ID_Reserva, Fecha_Desde, Cantidad_Noches, Cantidad_Huespedes, ID_Cliente, ID_Habitacion, ID_Regimen, Estado)
SELECT DISTINCT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, x.Cantidad_Huespedes_Total, c.ID_Cliente, h.ID_Habitacion, r.ID_Regimen, 'Correcta'
FROM gd_esquema.Maestra m, AEFI.TL_Tipo_Habitacion x ,AEFI.TL_Cliente c, AEFI.TL_Habitacion  h, AEFI.TL_Regimen r, AEFI.TL_Hotel ho
WHERE m.Habitacion_Tipo_Codigo= x.ID_Tipo_Habitacion
AND m.Cliente_Pasaporte_Nro = c.Documento_Nro 
AND m.Cliente_Apellido= c.Apellido 
AND m.Cliente_Nombre= c.Nombre
AND m.Habitacion_Numero = h.Numero
AND m.Hotel_Calle = ho.Calle
AND m.Hotel_Ciudad = ho.Ciudad
AND m.Hotel_Nro_Calle = ho.Nro_Calle
AND h.ID_Hotel = ho.ID_Hotel
AND m.Regimen_Descripcion = r.Descripcion
SET IDENTITY_INSERT AEFI.TL_Reserva OFF
	
	

--Uso codigos que ya existen
	SET IDENTITY_INSERT [AEFI].[TL_Consumible] ON
	INSERT INTO [AEFI].[TL_Consumible](ID_Consumible, Descripcion, Precio)
	SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	FROM gd_esquema.Maestra 
	WHERE Consumible_Codigo IS NOT NULL
	SET IDENTITY_INSERT [AEFI].[TL_Consumible] OFF




	SET IDENTITY_INSERT [AEFI].[TL_Factura] ON
INSERT INTO [AEFI].[TL_Factura](ID_Factura, Fecha, Total, ID_Cliente)
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, x.ID_Cliente
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Cliente x ON (x.Documento_Nro = m.Cliente_Pasaporte_Nro AND x.Nombre = m.Cliente_Nombre AND x.Apellido = m.Cliente_Apellido)
WHERE m.Factura_Nro IS NOT NULL;

	SET IDENTITY_INSERT [AEFI].[TL_Factura] OFF

INSERT INTO [AEFI].[TL_Estadia](ID_Reserva, Fecha_Inicio, Cantidad_Noches,Estado, ID_Factura)
SELECT DISTINCT r.ID_Reserva, m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches, (CASE WHEN (DATEADD(day, m.estadia_cant_noches, m.estadia_fecha_inicio) > GETDATE()) THEN 1 ELSE 0 END) as activa , f.ID_Factura
FROM gd_esquema.Maestra m, AEFI.TL_Reserva r, AEFI.TL_Factura f
WHERE r.ID_Reserva = m.Reserva_Codigo
AND f.ID_Factura = m.Factura_Nro
AND m.Estadia_Cant_Noches IS NOT NULL AND m.Estadia_Fecha_Inicio IS NOT NULL
AND m.Factura_Total IS NOT NULL;


INSERT INTO AEFI.TL_Consumible_Por_Estadia
SELECT c.ID_Consumible, m.Item_Factura_Cantidad, e.ID_Estadia
FROM gd_esquema.Maestra m, AEFI.TL_Consumible c, AEFI.TL_Estadia e
WHERE m.Consumible_Codigo = c.ID_Consumible AND e.ID_Reserva=m.Reserva_Codigo;

INSERT INTO AEFI.TL_Item_Por_Factura (ID_Consumible, Cantidad, ID_Factura, Monto) --268809 consumibles
SELECT m.Consumible_Codigo, m.Item_Factura_Cantidad, f.ID_Factura, m.Item_Factura_Monto 
FROM gd_esquema.Maestra m, AEFI.TL_Factura f
WHERE f.ID_Factura = m.Factura_Nro
AND m.Consumible_Codigo IS NOT NULL;


INSERT INTO AEFI.TL_Item_Por_Factura (ID_Estadia, Cantidad, ID_Factura, Monto)--89603 estadias
SELECT DISTINCT e.ID_Estadia, m.Item_Factura_Cantidad, f.ID_Factura, m.Item_Factura_Monto 
FROM gd_esquema.Maestra m, AEFI.TL_Factura f, AEFI.TL_Estadia e
WHERE f.ID_Factura = m.Factura_Nro
AND e.ID_Reserva = m.Reserva_Codigo
AND m.Consumible_Codigo IS NULL;

	
INSERT INTO AEFI.TL_Puntos_Por_Factura
SElECT ID_Factura, ID_Cliente, Fecha, (SELECT (SUM(ipf.Monto/10) + SUM(ipf1.Monto/5))
							FROM AEFI.TL_Item_Por_Factura ipf, AEFI.TL_Item_Por_Factura ipf1
							WHERE ipf.ID_Estadia IS NOT NULL 
							AND ipf1.ID_Consumible IS NOT NULL
							AND ipf.ID_Factura = f.ID_Factura
							AND ipf1.ID_Factura = f.ID_Factura)
FROM AEFI.TL_Factura f;



UPDATE AEFI.TL_Reserva
SET ESTADO = 'Efectivizada'
FROM AEFI.TL_Estadia e, AEFI.TL_Reserva r
WHERE e.ID_Reserva = r.ID_Reserva	


INSERT INTO AEFI.TL_Regimen_Por_Hotel
SELECT DISTINCT h.ID_Hotel, r.ID_Regimen
FROM gd_esquema.Maestra m, AEFI.TL_Hotel h, AEFI.TL_Regimen r
WHERE h.Nro_Calle = m.Hotel_Nro_Calle AND h.Calle = m.Hotel_Calle AND h.Ciudad = m.Hotel_Ciudad
AND r.Descripcion = m.Regimen_Descripcion;


COMMIT




