create proc ProcWithCreateNonTempTableStatement
as
begin
create table p_t1 ( a char(1) ) -- not ok
create table p_t2 ( a char(1) collate Latin1_General_CI_AS ) -- not ok
create table p_t3 ( a char(1) collate DATABASE_DEFAULT ) -- ok
end 
