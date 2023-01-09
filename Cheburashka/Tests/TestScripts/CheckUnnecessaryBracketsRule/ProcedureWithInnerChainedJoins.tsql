CREATE proc dbo.ProcedureWithInnerChainedJoins
AS
declare @MaxRow int,@MinRow int
		SELECT * FROM 
		(SELECT TOP (@MaxRow) ROW_NUMBER() Over (ORDER BY a.a DESC, b.a DESC)
			as Row_Index,
a.*,b.*,c.*,d.*
		from    Table5 a
		INNER JOIN    Table5 b ON (a.a = b.a) 
		INNER JOIN    Table5 c ON a.a = c.a
		INNER JOIN    Table5 d ON (a.a = d.a and a.a = d.a)		
		where
			a.a= 1
		order by a.a
		) as rowtable WHERE Row_Index >= @MinRow AND Row_Index <= @MaxRow