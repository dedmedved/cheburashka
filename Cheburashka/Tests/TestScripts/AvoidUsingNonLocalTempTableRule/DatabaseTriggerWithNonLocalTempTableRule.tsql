

CREATE TRIGGER [DatabaseTriggerWithNonLocalTempTable]
    ON database
FOR DROP_SYNONYM    
    AS
    begin
    select * from  #A
    select * from  ##A
    END
go
