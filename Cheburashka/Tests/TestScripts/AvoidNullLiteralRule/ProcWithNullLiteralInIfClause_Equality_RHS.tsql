create procedure ProcWithNullLiteralInIfClause_Equality_RHS
as
begin
	declare @a int = null;
	if null = @a begin
		SELECT a
		FROM dbo.table1
	end ;
end