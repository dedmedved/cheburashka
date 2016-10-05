
create procedure ProcWithVariableThatIsWrittenTo
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    set @A = 1
    print isnull(@A, -1)
end