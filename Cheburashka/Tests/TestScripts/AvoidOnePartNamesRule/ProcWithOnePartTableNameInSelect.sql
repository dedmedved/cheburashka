
create procedure dbo.ProcWithOnePartTableNameInSelect
as
begin
    select * from Table1  -- Table1 has no schema. This should be flagged as a problem
end