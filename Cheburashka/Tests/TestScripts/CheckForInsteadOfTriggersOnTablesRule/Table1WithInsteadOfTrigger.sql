﻿create table Table1 ( a int, b int);
go
create trigger trg_1 on taBle1 
instead of update 
as
begin
select 1
end ;
go
