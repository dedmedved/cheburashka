
create function ScalarValuedFunctionShowsThatReturnIsTreatedAsAValueConsumer()
returns int
as
begin
    declare @A int  -- @A is a return value. This should NOT be flagged as a problem
    set @A = 1 
    return @A
end