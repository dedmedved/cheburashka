create trigger dbo.[TableTriggerWithOnePartNameInSelect] on dbo.Table1
    after insert
as
    select * from Table1  -- Table1 has no schema. This should be flagged as a problem

