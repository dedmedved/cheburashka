CREATE proc dbo.ProcedureWithOKMergeInsertColumns
AS
merge into
Table1 trg
using (select 1 as a, 1 as b, 1 as c) src
on src.a = trg.a
when not matched by target
then insert (a,b) values (src.a,src.b)
;

go
