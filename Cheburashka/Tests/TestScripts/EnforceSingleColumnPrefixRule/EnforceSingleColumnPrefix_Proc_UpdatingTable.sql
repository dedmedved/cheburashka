create proc EnforceSingleColumnPrefix_Proc_UpdatingTable
as
update  dbo.Table1
set     dbo.Table1.a    = dbo.Table1.b
from    dbo.Table1
;
