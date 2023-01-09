create trigger dbo.[TableTriggerWithUninitialisedVariable] on dbo.Table1
    after insert
as
declare @A int      -- @A is Uninitialised. This should be flagged as a problem
print isnull(@a, -1)

