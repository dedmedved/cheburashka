CREATE TRIGGER [ServerTriggerWithCaptureOfSPReturnStatus]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
    declare @RC int
      exec @RC = dbo.ProcWithCaptureOfSPReturnStatus; -- Captures return status. This is OK.
    END
