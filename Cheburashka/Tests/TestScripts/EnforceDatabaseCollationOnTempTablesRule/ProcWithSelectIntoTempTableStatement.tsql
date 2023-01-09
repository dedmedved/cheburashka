create proc ProcWithSelectIntoTempTableStatement
as
begin
create table #p_t1 ( a char(1) collate database_DEFAULT)
select *, cast('a' as char(10)) collate Latin1_General_CI_AS  as b      -- can catch explicit collate in select into, but not much more
into #p_t2
from #p_t1
end 
