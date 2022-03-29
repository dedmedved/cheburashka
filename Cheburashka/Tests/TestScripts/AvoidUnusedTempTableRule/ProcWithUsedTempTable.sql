
create procedure ProcWithUsedTempTable
as
begin
    create table #A(a int)  
    insert into #A values(1)
    select * from #A
end