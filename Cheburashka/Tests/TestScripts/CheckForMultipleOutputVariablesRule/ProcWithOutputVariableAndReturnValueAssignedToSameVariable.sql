create proc ProcWithOutputVariableAndReturnValueAssignedToSameVariable @var1 int output, @var2 int output
as
begin
declare @a int = 1
declare @b int = 2
exec @a = ProcWithOutputVariableAndReturnValueAssignedToSameVariable @var1 = @a output, @var2 = @B output
end
go