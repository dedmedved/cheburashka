
CREATE PROCEDURE dbo.ProcWithOutReturn
AS 
BEGIN
      exec dbo.ProcWithoutReturn; -- Doesn't use Return. This should be flagged as a problem.
END