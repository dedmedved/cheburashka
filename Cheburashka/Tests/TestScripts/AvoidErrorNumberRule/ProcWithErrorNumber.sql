
CREATE PROCEDURE ProcWithErrorNumber
AS 
BEGIN
  RETURN @@ERROR; -- Uses @@ERROR . This should be flagged as a problem
EXIT_PROC:
END