
create procedure ProcWithVariableThatIsWrittenToByExecute
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    exec @A = ProcWithVariableThatIsWrittenToByExecute
    print isnull(@a, -1)
end