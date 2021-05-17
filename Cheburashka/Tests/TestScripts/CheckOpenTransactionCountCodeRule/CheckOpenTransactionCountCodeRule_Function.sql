﻿create Function CheckOpenTransactionCountCodeRule_Function()
RETURNS INT
AS
BEGIN
IF @@TRANCOUNT = 1 ROLLBACK
IF XACT_STATE() = 1 ROLLBACK
IF @@TRANCOUNT = 1 OR XACT_STATE() = 1 ROLLBACK;
RETURN 1;
END;
