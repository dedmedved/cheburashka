
create procedure ProcWithUseOfInterimChainedWriteOnlyVariables
as
begin
    declare @A int
    ,   @b int -- @B is only written to . This should be flagged as a problem
    set @A = 1 
    set @B = @A
    return    @A
end