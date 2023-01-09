
-- At the moment this is questionable.
create procedure ProcWithChainedParameterWriteOnlyVariablesReversed 
    @A int  -- @A is only written to and uses the setting of @B . This should be flagged as a problem
as
begin
    declare @B int  -- @B is only written to . This should be flagged as a problem
    set @b = 1
    set @A = @B 
end