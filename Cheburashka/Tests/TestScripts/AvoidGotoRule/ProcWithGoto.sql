
CREATE PROCEDURE ProcWithGoto
AS 
BEGIN
  GOTO EXIT_PROC; -- Uses GOTO . This should be flagged as a problem
EXIT_PROC:
END