
create procedure ProcWithExplicitlyInitialisedVariable
as
begin
    declare @A int  = 1 -- @A is initialised. This should NOT be flagged as a problem
    print isnull(@A, -1)
end