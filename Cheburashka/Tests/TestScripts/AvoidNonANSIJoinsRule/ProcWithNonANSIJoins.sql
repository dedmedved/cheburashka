CREATE PROCEDURE ProcWithNonANSIJoins
AS 
BEGIN
 SELECT * 
 from dbo.Table1 z 
 JOIN dbo.Table1 a
 ON z.[C1] = a.[C1],
 dbo.Table2,
 dbo.Table4, 
 (SELECT [C1] FROM dbo.Table3) x
 JOIN dbo.Table1 y
 ON x.[C1] = y.[C1]

EXIT_PROC:
END