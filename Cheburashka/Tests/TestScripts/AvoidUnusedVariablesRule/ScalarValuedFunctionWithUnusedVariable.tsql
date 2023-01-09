
create function ScalarValuedFunctionWithUnusedVariable()
returns int
as
begin
    declare @A int  -- @A is unused. This should be flagged as a problem
    return 2
end