﻿
create procedure ProcWithWriteOnlyVariableSetByAssignmentSet
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    update a
    set     @A = 1
    from    Table1 a
end