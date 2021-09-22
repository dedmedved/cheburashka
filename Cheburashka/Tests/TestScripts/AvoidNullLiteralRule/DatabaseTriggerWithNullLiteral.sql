create trigger [DatabaseTriggerWithNullLiteral] on database
    for drop_synonym
as
begin
    SELECT a
    FROM dbo.table1
    WHERE a = null
end
go
