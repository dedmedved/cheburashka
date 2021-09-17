create proc ProcWithAllParametersOK_CalledbyPosition @var1 int output, @var2 int output
as
begin
declare @rc int 
declare @a int = 1
declare @b int = 2
exec @rc = ProcWithAllParametersOK_CalledbyPosition @a output, @B output
end
go