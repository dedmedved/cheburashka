
create procedure ProcWithVariableThatIsWrittenToByExecuteParameterAndNotUsed
as
begin
    declare @a int  -- @A is set. This should NOT be flagged as a problem
	execute ProcWithVariableThatIsWrittenToByExecuteParameter @param1 = @A output
end
