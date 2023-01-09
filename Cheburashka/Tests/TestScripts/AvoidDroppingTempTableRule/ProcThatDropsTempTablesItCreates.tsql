
create procedure ProcThatDropsTempTablesItCreates
as
begin
    create table #A (a int)  
    create table ##A (a int) 
    select * into #B from #A
    drop table #A ;     -- flagged 
    drop table #B ;     -- flagged 
    drop table ##A ;    -- not flagged - table is global

end