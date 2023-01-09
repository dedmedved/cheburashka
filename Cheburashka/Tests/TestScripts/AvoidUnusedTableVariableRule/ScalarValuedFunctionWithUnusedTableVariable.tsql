create function ScalarValuedFunctionWithUnusedTableVariable()
returns int
as
begin

    declare @A table (a int)  -- @A is unused. This should be flagged as a problem
    return 2
end