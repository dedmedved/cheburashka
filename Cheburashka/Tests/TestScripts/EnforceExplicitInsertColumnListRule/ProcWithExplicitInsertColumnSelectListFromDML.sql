﻿create proc ProcWithExplicitInsertColumnSelectListFromDML
as
begin
insert into Table1 (a,b) select a,b
from (
insert into Table1 (a,b) 
output inserted.a, inserted.b
select a,b
from Table1
) src
;
end
go
