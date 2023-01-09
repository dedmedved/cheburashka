
create function TableValuedFunctionWithWriteOnlyVariable()
returns @X table ( a int )
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    set @a = 1 
    insert into @X values(1)
    return 
end