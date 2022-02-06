create table dbo.Table1 
(       a int not null
,       b int not null
,       c int
,       d as a+b
,       e int not null default 0
,       f int null
)
go
