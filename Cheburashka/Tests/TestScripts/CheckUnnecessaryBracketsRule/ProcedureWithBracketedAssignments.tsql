create table  dbo.Table6
(       a int not null
,       b int 
)
go
create index IX_TABLE6_01 on dbo.Table6 (b)
go

CREATE proc dbo.ProcedureWithBracketedAssignments
AS
DECLARE @a int = 1
set @a = 1

DECLARE @a1 int = (1)
set @a1 = (1)

DECLARE @a2 int = ((1))
set @a2 = ((1))

select @a2 = ((1))

update dbo.Table6
set a=(a)

go
