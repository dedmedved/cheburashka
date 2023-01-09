create table  dbo.Table4
(       a int not null
,       b int 
)
go
create index IX_TABLE4_01 on dbo.Table4 (b)
go

CREATE proc dbo.ProcedureWithDoubledBrackets
 
    AS
    BEGIN
        SELECT 1 FROM dbo.Table4 WHERE 1=1
        SELECT 1 FROM dbo.Table4 WHERE (1=1)
        SELECT 1 FROM dbo.Table4 WHERE ((1=1))                                          --bad
        SELECT 1 FROM dbo.Table4 WHERE (1=1) AND a = ((b + a ) + a)
        SELECT 1 FROM dbo.Table4 WHERE (1=1) AND a = (((b + a )) + a)                   --bad
        SELECT 1 FROM dbo.Table4 WHERE EXISTS ((SELECT 1 FROM dbo.Table4))              --bad
        SELECT 1 FROM dbo.Table4 WHERE ((EXISTS (SELECT 1 FROM dbo.Table4)))            --bad
        SELECT 1 FROM dbo.Table4 WHERE (1=1 and EXISTS (SELECT 1 FROM dbo.Table4))
        SELECT 1 FROM dbo.Table4 WHERE (EXISTS (SELECT 1 FROM dbo.Table4))
    END
go
