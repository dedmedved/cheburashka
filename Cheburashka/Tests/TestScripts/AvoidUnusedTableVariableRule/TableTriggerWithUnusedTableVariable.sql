create TRIGGER dbo.[TableTriggerWithUnusedTableVariable]
    ON dbo.Table1
    after insert
as
    declare @A table (a int)      -- @A is unused. This should be flagged as a problem

