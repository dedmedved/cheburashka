
CREATE PROCEDURE ProcWithInDirectUseOfRowcountViaInitialisation
AS 
BEGIN
  declare @R int = @@rowcount; -- Uses @@rowcount indirectly . This should NOT be flagged as a problem
  declare @E int = @@error;    -- Uses @@error    indirectly . This should NOT be flagged as a problem
END