﻿create proc ProcWithMergeWithExplicitInsertColumnSelectList
as
begin
merge into Table1 as tgt
using Table1 as src
on tgt.a=src.a
when not matched by target
then insert (a,b) values (src.a,src.b)
;
end
go