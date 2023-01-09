
CREATE PROCEDURE dbo.ProcWith3Returns1InCatchBlock
AS 
BEGIN
begin try
    return
    declare @RC int
      exec @RC = dbo.ProcWithReturn; 
    return;
end try
begin catch
    return;
end catch
END