create proc ProcWith2OutputVariablesAssignedToSameVariable @var1 int output, @var2 int output
as
begin
declare @a int = 1
declare @b int = 2
exec @b = ProcWith2OutputVariablesAssignedToSameVariable @var1 = @a output, @var2 = @a output
end
go