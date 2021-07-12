create table Table3 ( a int, b int);
go
create view View1 as select * from Table3;
go
create trigger vw_trg_1 on View1
instead of update 
as
begin
select 1
end ;
go
