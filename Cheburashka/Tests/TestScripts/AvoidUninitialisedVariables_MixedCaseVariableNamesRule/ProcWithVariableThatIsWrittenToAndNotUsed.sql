
create procedure ProcWithVariableThatIsWrittenToAndNotUsed
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    set @a = 1
end