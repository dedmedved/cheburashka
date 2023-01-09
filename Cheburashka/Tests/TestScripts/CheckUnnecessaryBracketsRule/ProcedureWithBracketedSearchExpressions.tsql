CREATE proc dbo.ProcedureWithBracketedSearchExpressions
AS

if (1=1 and 0=1)
select  a.a,count(*) 
from    Table5 a
JOIN    Table5 b ON (a.a = b.a) 
where   (a.a=1 and a.a=1)
group by a.a
having ( 1=1 and 2=2) 
;
while (1=1 and 0=1)
merge into Table5 t
using Table5 s
on (t.a=s.a and t.a=s.a)
when not matched by target and (t.a=s.a and t.a=s.a)
then insert (a,b)values (s.a,s.b)
when matched and (t.a=s.a and t.a=s.a)
then update set t.a=s.b
;
