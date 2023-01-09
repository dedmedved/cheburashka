
create function ScalarValuedFunctionWithWriteOnlyVariable()
returns int
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    set @a = 1 
    return 2
end