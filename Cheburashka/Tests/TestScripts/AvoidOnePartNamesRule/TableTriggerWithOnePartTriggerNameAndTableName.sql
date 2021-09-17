create trigger [TableTriggerWithOnePartTriggerNameAndTableName] on Table1  -- names have no schema. These should be flagged as problems
    after insert
as
    select * from dbo.Table1  

