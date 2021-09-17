create proc ProcWithAllParametersNotOK_CalledbyMix @var1 int output, @var2 int output, @var3 int output, @var4 int output
as
begin
declare @rc int 
declare @a int = 1
declare @b int = 2
declare @c int = 2
declare @d int = 2
exec @rc = ProcWithAllParametersNotOK_CalledbyMix @a output, @B output,@var3 = @c ,@var4 = @D
end
go