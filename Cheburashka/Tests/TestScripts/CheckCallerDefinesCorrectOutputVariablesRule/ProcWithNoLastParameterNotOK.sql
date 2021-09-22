create proc ProcWithNoLastParameterNotOK @var1 int output, @var2 int output
as
begin
declare @rc int 
declare @a int = 1
declare @b int = 2
exec @rc = ProcWithNoLastParameterNotOK @var1 = @a output
end
go