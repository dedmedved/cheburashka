CREATE proc dbo.ProcedureWithMissingInsertColumnsInOutputIntoClause_NULL
AS
insert into Table1 (a,b) 
output inserted.a into Table1 (a)
values (1,2)
;
go
