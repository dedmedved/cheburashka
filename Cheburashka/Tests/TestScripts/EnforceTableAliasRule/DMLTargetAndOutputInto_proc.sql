create procedure DMLTargetAndOutputInto_proc
as
begin

DECLARE @x TABLE ( a CHAR(10))
INSERT INTO Table1 VALUES(1)
INSERT INTO Table1 SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO Table3 SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO @x SELECT * FROM Table2
INSERT INTO Table1 output 'aa' INTO @x SELECT * FROM Table2,Table2 -- should be an erro but isn't

SELECT * FROM Table2,Table2
SELECT * FROM Table2 JOIN Table2 ON a=a

INSERT INTO Table1 
OUTPUT 'aa' INTO @x --error caused by not exists 
select  a.a
from    Table2 b
WHERE NOT EXISTS (select  a FROM    Table1 a WHERE a=a)

END

