CREATE PROCEDURE dbo.ProcWithSingleParameterSetToIntIsIgnored @var int 
AS 
BEGIN
set @var = 1; 
END
GO