CREATE proc dbo.ProcedureWithMissingInsertColumns_NULL
AS
insert into Table1 (a) values (1)
insert into Table1 (a) select a from Table1
;
go
