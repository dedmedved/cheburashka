
create procedure ProcWithWriteOnlyVariableSetByExecuteParameterNotUsingNamedParameters @param1 int output
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
	execute ProcWithWriteOnlyVariableSetByExecuteParameterNotUsingNamedParameters @A output
end