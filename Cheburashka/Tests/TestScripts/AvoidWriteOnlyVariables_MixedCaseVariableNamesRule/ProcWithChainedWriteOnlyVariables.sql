
create procedure ProcWithChainedWriteOnlyVariables
as
begin
    declare @A int  -- @A is only written to/used in the setting of @B . This should be flagged as a problem
    ,   @B int  -- @B is only written to . This should be flagged as a problem
    set @a = 1 
    set @B = @A
end