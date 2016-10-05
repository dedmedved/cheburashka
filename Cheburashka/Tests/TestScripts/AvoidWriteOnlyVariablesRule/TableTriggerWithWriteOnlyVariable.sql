create TRIGGER dbo.[TableTriggerWithWriteOnlyVariable]
    ON dbo.Table1
    after insert
as
    declare @A int      -- @A is only written to. This should be flagged as a problem
    set @A = 1
