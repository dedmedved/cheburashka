CREATE TRIGGER [DatabaseTriggerWithOutCaptureOfSPReturnStatus]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
      exec dbo.ProcWithoutCaptureOfSPReturnStatus; -- Doesn't capture return status. This should be flagged as a problem.
    END
go
