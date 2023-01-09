
create procedure ProcWithWriteOnlyVariableSetBySp_ExecuteSQLParameter @param1 int output
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
	execute sp_executesql N'select @P = 1', N'@P int output', @P = @a output
end