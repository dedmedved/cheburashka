
CREATE PROCEDURE dbo.ProcWith3Returns1InCatchBlock1OutsideTryBlock
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
return
END