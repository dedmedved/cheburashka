
create procedure ProcWithVariableThatIsWrittenToBySelect
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    select  @a = 1
    print isnull(@A, -1)
end