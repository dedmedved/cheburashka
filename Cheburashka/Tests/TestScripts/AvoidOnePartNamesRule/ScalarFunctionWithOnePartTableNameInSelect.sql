
create function dbo.ScalarFunctionWithOnePartTableNameInSelect()
returns int
as
begin
declare @a int
    select @a  =a from Table1  -- Table1 has no schema. This should be flagged as a problem
    return @a
end