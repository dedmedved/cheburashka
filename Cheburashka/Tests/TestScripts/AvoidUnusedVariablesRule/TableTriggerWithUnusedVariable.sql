create TRIGGER dbo.[TableTriggerWithUnusedVariable]
    ON dbo.Table1
    after insert
as
    declare @A int      -- @A is unused. This should be flagged as a problem

