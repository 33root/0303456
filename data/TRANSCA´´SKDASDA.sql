CREATE TRIGGER TR_Nueva_Estadia ON AEFI.TL_Estadia
FOR INSERT
AS
BEGIN TRANSACTION
declare @ID NUMERIC(18,0)
declare cursor_est cursor
	FOR SELECT ID_Estadia from Inserted
open cursor_est
fetch next from cursor_est INTO @ID
while @@fetch_status = 0
BEGIN
	UPDATE TL_Estadia
	SET monto = ( SELECT DISTINCT(m.Regimen_Precio *  m.Habitacion_Tipo_Porcentual) 
					FROM AEFI.TL_Estadia e, gd_esquema.Maestra m 
					WHERE e.ID_Reserva = m.Reserva_Codigo
					AND e.ID_Estadia = @ID
					)
	fetch next from cursor_est into @ID
	END
	close cursor_est
	deallocate cursor_est
	COMMIT
;				
