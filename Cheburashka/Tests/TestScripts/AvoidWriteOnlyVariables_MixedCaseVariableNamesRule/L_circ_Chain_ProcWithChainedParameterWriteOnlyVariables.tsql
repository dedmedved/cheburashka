
create procedure L_circ_Chain_ProcWithChainedParameterWriteOnlyVariables 
    @A int  
as
begin
    declare @B int  -- @B is only written to . This should be flagged as a problem
	,   @c int
	,   @d int
	,   @E int

    set @A = 1 
    set @B = @A
	set @c = @B
	set @e = @c

	set @d = @c
	set @c = @D
end