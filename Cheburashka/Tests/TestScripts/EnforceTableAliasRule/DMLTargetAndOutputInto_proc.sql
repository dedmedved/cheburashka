create procedure DMLTargetAndOutputInto_proc
as
begin

DECLARE @x TABLE ( a CHAR(10))
INSERT INTO Table1 VALUES(1)
INSERT INTO Table1 SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO Table3 SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO @x SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO @x SELECT * FROM Table2,Table2 

SELECT * FROM dbo.Table2,dbo.Table2
SELECT * FROM Table2 JOIN Table2 ON a=a

INSERT INTO Table1 
OUTPUT 'aa' INTO @x 
select  a.a
from    Table2 b
WHERE NOT EXISTS (select  a FROM Table1 a WHERE a=a)

UPDATE t 
SET a=1
OUTPUT 'aa' INTO @x 
FROM Table1 t
WHERE NOT EXISTS (select  a FROM Table1 a WHERE a=a)
END

