
create procedure ProcWithUninitialisedVariable
as
begin
    declare @A int  -- @A is uninitialised. This should be flagged as a problem
    print isnull(@A, -1)
end