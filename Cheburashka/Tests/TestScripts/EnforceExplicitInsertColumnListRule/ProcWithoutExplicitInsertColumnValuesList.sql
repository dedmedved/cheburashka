create proc ProcWithoutExplicitInsertColumnValuesList
as
begin
insert into Table1  values (1,2);
end
go