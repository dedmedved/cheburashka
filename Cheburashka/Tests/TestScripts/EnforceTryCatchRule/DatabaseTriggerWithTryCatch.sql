CREATE TRIGGER [DatabaseTriggerWithTryCatch]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
    begin try
    declare @RC int
      exec @RC = dbo.ProcWithTryCatch; -- Uses TRY/CATCH. This is OK.
    end try
    begin catch
      print error_message()
    end catch
    END
go
