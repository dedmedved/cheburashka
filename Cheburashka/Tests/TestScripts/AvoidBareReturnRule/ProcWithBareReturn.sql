
CREATE PROCEDURE ProcWithBareReturn
AS 
BEGIN
  RETURN; -- No return value. This should be flagged as a problem

END