
DROP PROCEDURE AEFI.cancelarReserva;
DROP PROCEDURE AEFI.modificar_nombre_rol
DROP PROCEDURE AEFI.quitar_Rol_Usuario;
DROP PROCEDURE AEFI.insertar_Rol_Usuario;
DROP PROCEDURE AEFI.deshabilitarUsuario;
DROP PROCEDURE AEFI.insertar_Hotel_Usuario;
DROP PROCEDURE AEFI.eliminar_Hotel_Usuario;
DROP PROCEDURE AEFI.quitarConsumiblePorEstadia;
DROP PROCEDURE AEFI.agregarConsumiblePorEstadia;
DROP PROCEDURE AEFI.generarEgresoEstadia;
DROP PROCEDURE AEFI.generarIngresoEstadia;
DROP PROCEDURE AEFI.cancelar_Reserva;
DROP PROCEDURE AEFI.top5_puntosCliente;
DROP PROCEDURE AEFI.top5_vecesReservada;
DROP PROCEDURE AEFI.top5_diasOcupados;
DROP PROCEDURE AEFI.top5_diasFueraDeServicio;
DROP PROCEDURE AEFI.top5_reservasCanceladas;
DROP PROCEDURE AEFI.top5_consumiblesFacturados;
DROP PROCEDURE AEFI.insertar_Reserva;
DROP PROCEDURE AEFI.insertar_nueva_Tarjeta;
DROP PROCEDURE AEFI.insertar_Registro_Pago_Sin_Tarjeta;
DROP PROCEDURE AEFI.insertar_Registro_Pago_Con_Tarjeta;
DROP PROCEDURE AEFI.insertar_item_precio_diasNoAlojados;
DROP PROCEDURE AEFI.insertar_item_consumible;
DROP PROCEDURE AEFI.calcular_costo_porDia;
DROP PROCEDURE AEFI.insertar_item_precio_estadia;
DROP FUNCTION AEFI.calcular_consumibles;
DROP FUNCTION AEFI.calcular_costo_habitacion;
DROP PROCEDURE AEFI.insertar_factura;
DROP PROCEDURE AEFI.crear_usuario_por_hotel;
DROP PROCEDURE AEFI.crear_usuario_por_rol;
DROP PROCEDURE AEFI.crear_usuario;
DROP PROCEDURE AEFI.baja_Hotel;
DROP PROCEDURE AEFI.baja_Habitacion;
DROP PROCEDURE AEFI.habilitar_rol;
DROP PROCEDURE AEFI.inhabilitar_rol;
DROP PROCEDURE AEFI.eliminar_funcionalidad_rol;
DROP PROCEDURE AEFI.insertar_rol_funcionalidad;
DROP PROCEDURE AEFI.crear_Habitacion;
DROP PROCEDURE AEFI.actualizar_Habitacion;
DROP PROCEDURE AEFI.actualizar_Hotel;
DROP PROCEDURE AEFI.actualizar_cliente;
DROP PROCEDURE AEFI.insertar_cliente;
DROP PROCEDURE AEFI.crear_Hotel;
DROP PROCEDURE AEFI.modificar_Reserva

DROP TABLE [AEFI].[TL_Registro_Evento];
DROP TABLE [AEFI].[TL_Puntos_Por_Factura];
DROP TABLE [AEFI].[TL_Consumible_Por_Estadia];
DROP TABLE [AEFI].[TL_Usuario_Por_Hotel];
DROP TABLE [AEFI].[TL_Regimen_Por_Hotel];
DROP TABLE [AEFI].[TL_Item_Por_Factura];
DROP TABLE [AEFI].[TL_Usuario_Por_Rol];
DROP TABLE [AEFI].[TL_Funcionalidad_Rol];
DROP TABLE [AEFI].[TL_Tarjeta];
DROP TABLE [AEFI].[TL_Registro_Pago];
DROP TABLE [AEFI].[TL_Tipo_Documento];
DROP TABLE [AEFI].[TL_Estadia];
DROP TABLE [AEFI].[TL_Factura];
DROP TABLE [AEFI].[TL_Consumible];
DROP TABLE [AEFI].[TL_Cancelacion];
DROP TABLE [AEFI].[TL_Reserva];
DROP TABLE [AEFI].[TL_Tipo_Habitacion];
DROP TABLE [AEFI].[TL_Baja_Hotel];
DROP TABLE [AEFI].[TL_Habitacion];
DROP TABLE [AEFI].[TL_Regimen];
DROP TABLE [AEFI].[TL_Hotel];
DROP TABLE [AEFI].[TL_Funcionalidad];
DROP TABLE [AEFI].[TL_Rol];
DROP TABLE [AEFI].[TL_Cliente];
DROP TABLE [AEFI].[TL_Usuario];

DROP SCHEMA [AEFI];
