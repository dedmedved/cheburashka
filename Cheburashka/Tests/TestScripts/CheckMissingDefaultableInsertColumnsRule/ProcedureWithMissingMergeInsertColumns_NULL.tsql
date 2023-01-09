CREATE proc dbo.ProcedureWithMissingMergeInsertColumns_NULL
AS
merge into
Table1 trg
using (select 1 as a, 1 as b, 1 as c) src
on src.a = trg.a
when not matched by target
then insert (a) values (src.a)
;

go
