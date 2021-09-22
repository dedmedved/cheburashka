
create procedure ProcWithVariableThatIsNotWrittenToByExecuteParameterNotUsingNamedParameters @param1 int output
as
begin
    declare @A int  -- @A is not set. This should be flagged as a problem
	execute ProcWithVariableThatIsWrittenToByExecuteParameter @A 
    print isnull(@A, -1)
end