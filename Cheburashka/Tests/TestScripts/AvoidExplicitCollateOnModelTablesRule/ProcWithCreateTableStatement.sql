﻿create proc ProcWithCreateTableStatement
as
begin
create table p_t1 ( a char(1) collate Latin1_General_CI_AS ) -- not ok
create table #p_t1 ( a char(1) collate DATABASE_DEFAULT ) -- ok
end 
