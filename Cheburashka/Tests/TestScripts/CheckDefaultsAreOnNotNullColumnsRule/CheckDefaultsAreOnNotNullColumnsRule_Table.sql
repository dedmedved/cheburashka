CREATE TABLE dbo.CheckDefaultsAreOnNotNullColumnsRule_Table
(       a int not null
,       b int     NULL DEFAULT (0)
,       c int NOT null DEFAULT (0)
,       d int     null
) ;
GO
