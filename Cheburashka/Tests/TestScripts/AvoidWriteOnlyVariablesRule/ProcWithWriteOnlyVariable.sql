﻿
create procedure ProcWithWriteOnlyVariable
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    set @A = 1 
end