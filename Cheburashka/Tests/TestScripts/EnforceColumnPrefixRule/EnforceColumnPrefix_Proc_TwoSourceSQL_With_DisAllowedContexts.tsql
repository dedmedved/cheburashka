create proc EnforceColumnPrefix_Proc_TwoSourceSQL_With_DisAllowedContexts
as
begin

update a
set a = 1
from Table1 a
,    Table2 b

update a
set a = 1
from Table1 a
join Table2 b
on a.a=b.a

merge into Table1 trg
using (
select a.a
from Table1 a
join Table2 b
on a.a=b.a
) as src
on trg.a = src.a
when not matched
then insert (a) values (a)
when matched
then update set a = a
OUTPUT DELETED.a, $action AS [Action], INSERTED.a 
into dbo.Table2 (a,b,c) 
;

end
