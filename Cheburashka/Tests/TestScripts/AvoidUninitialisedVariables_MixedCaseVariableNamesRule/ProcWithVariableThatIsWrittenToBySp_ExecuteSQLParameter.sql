
create procedure ProcWithVariableThatIsWrittenToBySp_ExecuteSQLParameter
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
	execute sp_executesql N'select @P = 1', N'@P int output', @P = @a output
    print isnull(@A, -1)
end