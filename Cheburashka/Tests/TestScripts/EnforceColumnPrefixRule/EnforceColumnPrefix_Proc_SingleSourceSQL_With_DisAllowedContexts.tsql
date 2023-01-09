create proc EnforceColumnPrefix_Proc_SingleSourceSQL_With_DisAllowedContexts
as
begin
insert into Table1 (a) values (1);
CREATE CLUSTERED INDEX cix_vw_service_agreement_lines_cleansed_for_date_range 
ON      Table1 
		(a);
update a
set a = 1
from Table1 a

merge into Table1 trg
using (select 1 as a ) as src
on trg.a = src.a
when not matched
then insert (a) values (src.a)
when matched
then update set a = a
OUTPUT DELETED.a, $action AS [Action], INSERTED.a 
into dbo.Table2 (a,b,c) 
;

end
