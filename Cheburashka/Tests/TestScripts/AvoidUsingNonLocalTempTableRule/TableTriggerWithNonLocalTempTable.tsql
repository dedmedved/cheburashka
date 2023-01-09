create TRIGGER dbo.[TableTriggerWithNonLocalTableVariable]
    ON dbo.Table1
    after insert
as
    select * from  #A
    select * from  ##A


