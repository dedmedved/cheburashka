create function ScalarValuedFunctionWithUnusedParameter(@UnusedParameter  int) -- @UnusedParameter is unused. This should be flagged as a problem
returns int
as
begin
    return 2
end