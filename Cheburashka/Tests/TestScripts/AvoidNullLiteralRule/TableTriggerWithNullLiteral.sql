create trigger dbo.[TableTriggerWithNullLiteral] on dbo.Table1
    after insert
as
    SELECT a
    FROM dbo.table1
    WHERE a = null

