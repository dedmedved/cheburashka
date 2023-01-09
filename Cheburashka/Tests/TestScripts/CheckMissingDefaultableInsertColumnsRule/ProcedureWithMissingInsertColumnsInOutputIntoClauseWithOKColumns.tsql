CREATE proc dbo.ProcedureWithMissingInsertColumnsInOutputIntoClauseWithOKColumns
AS
insert into Table1 (a,b) 
output inserted.a,inserted.b into Table1 (a,b)
values (1,2);
go
