create trigger DatabaseTriggerWithOnePartTableNameInSelect on database
    for drop_synonym
as
begin
    select * from Table1  -- Table1 has no schema. This should be flagged as a problem
end
go
