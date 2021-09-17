
create procedure ProcWithVariableThatIsWrittenToByExecuteParameterAndNotUsed
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
	execute ProcWithVariableThatIsWrittenToByExecuteParameter @param1 = @A output
end
