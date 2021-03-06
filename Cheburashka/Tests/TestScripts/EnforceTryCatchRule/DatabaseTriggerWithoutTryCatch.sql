CREATE TRIGGER [DatabaseTriggerWithOutTryCatch]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
      exec dbo.ProcWithoutTryCatch; -- Doesn't use TRY/CATCH. This should be flagged as a problem.
    END
go
