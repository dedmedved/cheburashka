
create function TableValuedFunctionWithUninitialisedVariable ()
returns @X table (a int)
as
begin
    declare @A int  --- @A is uninitialised. This should be flagged as a problem
    print isnull(@A, -1)
    insert  into @X
    values  (1)
    return 
end