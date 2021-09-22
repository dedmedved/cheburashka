create proc ProcWithoutExplicitInsertColumnSelectList
as
begin
insert into Table1 select 1,2;
end
go