
create procedure OP_ProcWithChainedParameterWriteOnlyVariables 
    @A int  
,   @Z int output
as
begin
    declare @B int  -- @B is used to set @Z. This should NOT be flagged as a problem
    set @A = 1 
    set @b = @a
	set @Z = @B
end