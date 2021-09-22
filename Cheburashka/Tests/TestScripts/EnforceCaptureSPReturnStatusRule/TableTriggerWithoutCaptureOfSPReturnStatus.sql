create TRIGGER dbo.[TableTriggerWithOutCaptureOfSPReturnStatus]
    ON dbo.Table1
    after insert
as
      exec dbo.ProcWithoutCaptureOfSPReturnStatus; -- Doesn't capture return status. This should be flagged as a problem.

