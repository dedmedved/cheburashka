
create procedure ProcWithWriteOnlyVariableSetByExecute
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    exec @A = ProcWithWriteOnlyVariableSetByExecute
end