
create function TableValuedFunctionWithNullLiteral ()
returns @X table (a int)
as
begin
    insert  into @X
    SELECT a
    FROM dbo.table1
    WHERE a = null
    return 
end