create procedure ProcWithNullLiteralInIfClause_Equality_LHS
as
begin
	declare @a int = null;
	if @a = null begin
		SELECT a
		FROM dbo.table1
	end ;
end