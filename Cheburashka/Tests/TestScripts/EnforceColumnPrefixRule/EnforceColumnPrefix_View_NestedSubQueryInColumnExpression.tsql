CREATE VIEW EnforceColumnPrefix_View_NestedSubQueryInColumnExpression
AS
SELECT (a + a + (SELECT  max( a+a) FROM dbo.Table1)) as a FROM dbo.Table1 ;