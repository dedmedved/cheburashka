
create procedure dbo.ProcWithOnePartTempTableNameInSelect
as
begin
    create table #Table1(a int)
    select * from #Table1  -- Temp Table1 has no schema. This IS NOT a problem
end