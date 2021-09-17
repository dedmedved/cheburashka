create proc ProcWithExplicitInsertColumnValuesList
as
begin
insert into Table1 (a,b) values (1,2);
end
go