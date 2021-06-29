CREATE PROCEDURE dbo.ProcWithSingleVariableFetchSetToIntIsIgnored
AS 
BEGIN
    declare @VAR INT;
    DECLARE c CURSOR FOR SELECT a FROM Table1
    OPEN c
    FETCH next FROM c INTO @var;
    CLOSE c
    DEALLOCATE c
END
GO