
create procedure ProcWithVariableThatIsWrittenToByExecuteParameterNotUsingNamedParameters @param1 int output
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
	execute ProcWithVariableThatIsWrittenToByExecuteParameter @A output
    print isnull(@A, -1)
end