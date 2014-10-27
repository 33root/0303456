BEGIN TRANSACTION

INSERT INTO [AEFI].[TL_Usuario](username, password)
SELECT m.Cliente_Nombre + '_' + m.Cliente_Apellido, '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4' /*Borre el DISTINCT para no perder registros */
FROM gd_esquema.Maestra m
WHERE Cliente_Nombre IS NOT NULL;

INSERT INTO AEFI.TL_Cliente(Nombre,Apellido,ID_Tipo_Documento,Documento_Nro,Mail,Calle,Calle_Nro,Piso,Dpto,Fecha_Nacimiento,Nacionalidad,Localidad,PaisOrigen)
SELECT DISTINCT m.Cliente_Nombre, m.Cliente_Apellido ,2, m.Cliente_Pasaporte_Nro, m.Cliente_Mail, m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, m.Cliente_Fecha_Nac, m.Cliente_Nacionalidad,'CABA','Argentina' 
FROM gd_esquema.Maestra m
WHERE Cliente_Apellido IS NOT NULL AND Cliente_Nombre IS NOT NULL

INSERT INTO [AEFI].[TL_Hotel](Calle,Nro_Calle,Ciudad,Cantidad_Estrellas,Recarga_Estrellas, Pais)
SELECT DISTINCT Hotel_Calle, Hotel_Nro_Calle, Hotel_Ciudad, Hotel_CantEstrella, Hotel_Recarga_Estrella, 'Argentina'
FROM gd_esquema.Maestra
SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion ON

	/*TODO: Setear cantidad de huespedes total a manopla*/
INSERT INTO AEFI.TL_Tipo_Habitacion(ID_Tipo_Habitacion, Descripcion, Porcentual)
SELECT DISTINCT m.Habitacion_Tipo_Codigo, m.Habitacion_Tipo_Descripcion, m.Habitacion_Tipo_Porcentual 
FROM gd_esquema.Maestra m
SET IDENTITY_INSERT AEFI.TL_Tipo_Habitacion OFF


UPDATE AEFI.TL_Tipo_Habitacion 
SET Cantidad_Huespedes_Total = 2
WHERE Descripcion = 'Base Doble' OR Descripcion = 'King';

UPDATE AEFI.TL_Tipo_Habitacion
SET Cantidad_Huespedes_Total = 3
WHERE Descripcion = 'Base Triple';

UPDATE AEFI.TL_Tipo_Habitacion 
SET Cantidad_Huespedes_Total = 4
WHERE Descripcion = 'Base Cuadruple';

UPDATE AEFI.TL_Tipo_Habitacion
SET Cantidad_Huespedes_Total = 1
WHERE Descripcion = 'Base Simple';


INSERT INTO [AEFI].[TL_Habitacion] (ID_Tipo_Habitacion, Numero, Piso, Vista, ID_Hotel)
SELECT DISTINCT t.ID_Tipo_Habitacion, m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.ID_Hotel
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Tipo_Habitacion t ON (m.Habitacion_Tipo_Codigo = t.ID_Tipo_Habitacion)
JOIN AEFI.TL_Hotel h ON (h.Calle = m.Hotel_Calle AND h.Nro_Calle=m.Hotel_Nro_Calle)




SET IDENTITY_INSERT AEFI.TL_Reserva ON

INSERT INTO [AEFI].[TL_Reserva] (ID_Reserva, Fecha_Desde, Cantidad_Noches, Cantidad_Huespedes, ID_Cliente, ID_Habitacion, ID_Regimen)
SELECT DISTINCT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, x.Cantidad_Huespedes_Total, c.ID_Cliente, h.ID_Habitacion, r.ID_Regimen
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Tipo_Habitacion x ON (m.Habitacion_Tipo_Codigo= x.ID_Tipo_Habitacion) 
JOIN AEFI.TL_Cliente c ON (m.Cliente_Pasaporte_Nro = c.Documento_Nro AND m.Cliente_Apellido= c.Apellido AND m.Cliente_Nombre= c.Nombre)
JOIN AEFI.TL_Habitacion  h ON (m.Habitacion_Numero = h.ID_Habitacion)
JOIN AEFI.TL_Regimen r ON (m.Regimen_Descripcion = r.Descripcion)

SET IDENTITY_INSERT AEFI.TL_Reserva OFF


INSERT INTO [AEFI].[TL_Regimen] (Descripcion,Precio_Base)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
FROM  gd_esquema.Maestra
	

--Uso codigos que ya existen
	SET IDENTITY_INSERT [AEFI].[TL_Consumible] ON
	INSERT INTO [AEFI].[TL_Consumible](ID_Consumible, Descripcion, Precio)
	SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	FROM gd_esquema.Maestra 
	WHERE Consumible_Codigo IS NOT NULL
	

	SET IDENTITY_INSERT [AEFI].[TL_Consumible] OFF
GO



INSERT INTO [AEFI].[TL_Factura](Numero, Fecha, Total, ID_Cliente)
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, x.ID_Cliente
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Cliente x ON (x.Documento_Nro = m.Cliente_Pasaporte_Nro)
WHERE m.Factura_Nro IS NOT NULL;


/*INSERT INTO [AEFI].[TL_Factura](Numero, Fecha, Total, ID_Cliente)
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, x.ID_Cliente
FROM gd_esquema.Maestra m
JOIN AEFI.TL_Cliente x ON (x.Documento_Nro = m.Cliente_Pasaporte_Nro AND x.Nombre = m.Cliente_Nombre AND x.Apellido = m.Cliente_Apellido)
WHERE m.Factura_Nro IS NOT NULL;
*/

INSERT INTO [AEFI].[TL_Estadia](Fecha_Inicio, Cantidad_Noches)
SELECT DISTINCT m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches
FROM gd_esquema.Maestra m

/*FALTA LA PARTE DE REGIMEN*/



COMMIT