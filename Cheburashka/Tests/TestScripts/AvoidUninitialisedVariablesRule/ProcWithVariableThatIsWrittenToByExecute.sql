
create procedure ProcWithVariableThatIsWrittenToByExecute
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    exec @A = ProcWithVariableThatIsWrittenToByExecute
    print isnull(@A, -1)
end