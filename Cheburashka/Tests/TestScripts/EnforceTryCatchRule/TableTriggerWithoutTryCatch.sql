create TRIGGER dbo.[TableTriggerWithOutTryCatch]
    ON dbo.Table1
    after insert
as
      exec dbo.ProcWithoutTryCatch; -- Doesn't use TRY/CATCH. This should be flagged as a problem.

