create procedure ProcWithNullLiteralInIfClause_InEquality_RHS
as
begin
	declare @a int = null;
	if null = @a begin
		SELECT a
		FROM dbo.table1
	end ;
end