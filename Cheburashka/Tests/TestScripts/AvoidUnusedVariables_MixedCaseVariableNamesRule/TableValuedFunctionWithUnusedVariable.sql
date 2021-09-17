
create function TableValuedFunctionWithUnusedVariable()
returns @X table ( a int )
as
begin
    declare @A int  --- @A is unused. This should be flagged as a problem
    insert into @X values(1)
    return 
end