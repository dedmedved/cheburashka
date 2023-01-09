CREATE proc dbo.ProcedureWithChainedJoins
AS
select * 
from    Table5 a
INNER JOIN    Table5 b ON (a.a = b.a) 
INNER JOIN    Table5 c ON a.a = c.a
INNER JOIN    Table5 d ON (a.a = d.a)
go
