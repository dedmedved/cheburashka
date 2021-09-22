CREATE TRIGGER [DatabaseTriggerWithCaptureOfSPReturnStatus]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
    declare @RC int
      exec @RC = dbo.ProcWithCaptureOfSPReturnStatus; -- Captures return status. This is OK.
    END
go
