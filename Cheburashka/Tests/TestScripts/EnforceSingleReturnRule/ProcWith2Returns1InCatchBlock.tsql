
CREATE PROCEDURE dbo.ProcWith2Returns1InCatchBlock
AS 
BEGIN
begin try
    declare @RC int
      exec @RC = dbo.ProcWithReturn; 
    return;
end try
begin catch
    return;
end catch
END