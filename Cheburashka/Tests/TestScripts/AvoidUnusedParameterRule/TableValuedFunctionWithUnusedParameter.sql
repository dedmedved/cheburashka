create function TableValuedFunctionWithUnusedParameter(@UnusedParameter  int) -- @UnusedParameter is unused. This should be flagged as a problem
returns @X table ( a int )
as
begin
    insert into @X values(1)
    return 
end