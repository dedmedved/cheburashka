create table  dbo.Table3
(       a int not null
,       b int 
)
go
create index IX_TABLE3_01 on dbo.Table3 (b)
go

CREATE TRIGGER DatabaseTriggerWithDoubledBrackets
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
        SELECT 1 FROM dbo.Table3 WHERE 1=1
        SELECT 1 FROM dbo.Table3 WHERE (1=1)
        SELECT 1 FROM dbo.Table3 WHERE ((1=1))                                          --bad
        SELECT 1 FROM dbo.Table3 WHERE (1=1) AND a = ((b + a ) + a)
        SELECT 1 FROM dbo.Table3 WHERE (1=1) AND a = (((b + a )) + a)                   --bad
        SELECT 1 FROM dbo.Table3 WHERE EXISTS ((SELECT 1 FROM dbo.Table3))              --bad
        SELECT 1 FROM dbo.Table3 WHERE ((EXISTS (SELECT 1 FROM dbo.Table3)))            --bad
        SELECT 1 FROM dbo.Table3 WHERE (1=1 and EXISTS (SELECT 1 FROM dbo.Table3))
        SELECT 1 FROM dbo.Table3 WHERE (EXISTS (SELECT 1 FROM dbo.Table3))
    END
go
