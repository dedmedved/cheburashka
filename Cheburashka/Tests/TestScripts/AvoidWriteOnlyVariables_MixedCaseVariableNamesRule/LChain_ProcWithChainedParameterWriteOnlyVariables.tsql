
create procedure LChain_ProcWithChainedParameterWriteOnlyVariables 
    @A int  
as
begin
    declare @B int  -- @B is only written to . This should be flagged as a problem
	,   @c int
	,   @d int
	,   @e int

    set @A = 1 
    set @b = @A
	set @c = @B
	set @d = @C
	set @e = @d
end