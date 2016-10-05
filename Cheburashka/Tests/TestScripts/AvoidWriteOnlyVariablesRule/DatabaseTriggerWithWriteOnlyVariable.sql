﻿CREATE TRIGGER [DatabaseTriggerWithWriteOnlyVariable]
    ON database
FOR DROP_SYNONYM    
    AS
    begin
    declare @A int      -- @A is only written to. This should be flagged as a problem
    set @A = 1
    END
go
