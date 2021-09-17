
create procedure ProcWithWriteOnlyVariableSetBySelect
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    select @a = 1 
end