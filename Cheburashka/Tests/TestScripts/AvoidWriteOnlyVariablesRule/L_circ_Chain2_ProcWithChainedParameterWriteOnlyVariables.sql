
create procedure L_circ_Chain2_ProcWithChainedParameterWriteOnlyVariables 
    @A int  
as
begin
    declare @B int  -- @B is only written to . This should be flagged as a problem
	,   @c int
	,   @d int
	,   @e int
	,   @f int
	,   @g int
	,   @h int

    set @A = 1 
    set @B = @A
	set @c = @B
	set @B = @c

	set @d = @c
	set @e = @d
	set @f = @e
	set @g = @f
	set @h = @g
	set @c = @h

end