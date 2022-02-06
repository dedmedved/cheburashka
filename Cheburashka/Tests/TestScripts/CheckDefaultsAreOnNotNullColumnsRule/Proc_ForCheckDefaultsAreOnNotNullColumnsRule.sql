CREATE proc dbo.Proc_ForCheckDefaultsAreOnNotNullColumnsRule
as
create table table2
(       a int not null
,       b int     NULL DEFAULT (0)
,       c int NOT null DEFAULT (0)
,       d int     null
,       e int          DEFAULT (0)
) ;
create table #table3
(       a int not null
,       b int     NULL DEFAULT (0)
,       c int NOT null DEFAULT (0)
,       d int     null
,       e int          DEFAULT (0)
) ;
declare @table3 table 
(       a int not null
,       b int     NULL DEFAULT (0)
,       c int NOT null DEFAULT (0)
,       d int     null
,       e int          DEFAULT (0)
) ;
GO
