create proc ProcWithInsertWithoutExplicitColumnListFromMergeWithoutExplicitInsertColumnSelectList
as
begin
insert into Table1 select a,b from (
merge into Table1 as tgt
using Table1 as src
on tgt.a=src.a
when not matched by target
then insert values (src.a,src.b)
output inserted.a, inserted.b
) src
;
end
go