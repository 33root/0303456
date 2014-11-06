CREATE TRIGGER TR_Nuevo_Consumible ON AEFI.TL_Consumible_Por_Estadia
AFTER INSERT
AS
BEGIN TRANSACTION
declare @ID1 NUMERIC(18,0)
declare @ID2 NUMERIC(18,0)

declare cursor_est cursor
	FOR SELECT ID_Estadia, ID_Consumible from Inserted
open cursor_est
fetch next from cursor_est INTO @ID1, @ID2
while @@fetch_status = 0
BEGIN
	UPDATE TL_Estadia
	SET Monto += ( SELECT DISTINCT(c.Precio) 
					FROM AEFI.TL_Estadia e, AEFI.TL_Consumible c, AEFI.TL_Consumible_Por_Estadia cpe
					WHERE e.ID_Estadia = cpe.ID_Estadia
					AND c.ID_Consumible = cpe.ID_Consumible
					AND cpe.ID_Estadia = @ID1
					AND cpe.ID_Consumible = @ID2
					)
	
	fetch next from cursor_est into @ID1, @ID2
	END
	close cursor_est
	deallocate cursor_est
	COMMIT
;				
