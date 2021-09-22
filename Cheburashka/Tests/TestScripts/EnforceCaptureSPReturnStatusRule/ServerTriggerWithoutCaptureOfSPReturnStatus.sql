CREATE TRIGGER [ServerTriggerWithOutCaptureOfSPReturnStatus]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
      exec dbo.ProcWithoutCaptureOfSPReturnStatus; -- Doesn't capture return status. This should be flagged as a problem.
    END
