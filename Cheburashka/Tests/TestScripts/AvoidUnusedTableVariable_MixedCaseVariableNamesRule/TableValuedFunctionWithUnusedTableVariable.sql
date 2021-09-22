create function TableValuedFunctionWithUnusedTableVariable()
returns @X table ( a int )
as
begin

    declare @A table (a int)  --- @A is unused. This should be flagged as a problem
    insert into @x values(1)
    return 
end