create proc ProcWithAlterTempTableStatement
as
begin
create table #p_t1 ( a char(1) collate database_DEFAULT)
alter table #p_t1 alter column a char(1)  -- not ok
alter table #p_t1 alter column a char(1) collate Latin1_General_CI_AS -- not ok
alter table #p_t1 alter column a char(1) collate database_DEFAULT --  ok
end 
