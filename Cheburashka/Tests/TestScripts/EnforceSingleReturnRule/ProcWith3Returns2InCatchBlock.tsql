
CREATE PROCEDURE dbo.ProcWith3Returns2InCatchBlock
AS 
BEGIN
begin try
    declare @RC int
      exec @RC = dbo.ProcWithReturn; 
    return;
end try
begin catch
    return;
    return
end catch
END