
create function dbo.TableValuedFunctionWithOnePartTableNameInSelect()
returns @X table (a int)
as
begin
    insert  into @X
    select  a from Table1   -- Table1 has no schema. This should be flagged as a problem
    return 
end
