create TRIGGER dbo.[TableTriggerWithCaptureOfSPReturnStatus]
    ON dbo.Table1
    after insert
as
    declare @RC int
      exec @RC = dbo.ProcWithCaptureOfSPReturnStatus; -- Captures return status. This is OK.

