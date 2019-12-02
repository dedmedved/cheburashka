
create function ScalarFunctionWithNullLiteral ()
returns int
as
BEGIN
    DECLARE @x int
    SELECT @x = a
    FROM dbo.table1
    WHERE a = null
    return @x
end