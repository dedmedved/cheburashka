
create procedure ProcWithCircularlyReferencedWriteOnlyVariables
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem -- BUT isnt
    declare @b int  -- @B is only written to. This should be flagged as a problem -- BUT isnt
    set @A = 1 
	set @B=@A
	set @A=@B
end