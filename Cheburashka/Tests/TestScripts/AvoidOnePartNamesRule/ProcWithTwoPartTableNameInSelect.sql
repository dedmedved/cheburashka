
create procedure dbo.ProcWithTwoPartTableNameInSelect
as
begin
    select * from dbo.Table1  -- Table1 has a schema. This is NOT a problem
end