create table  dbo.ProcedureWithAlterConstraints_Parent_Table
(       a int not null          primary key
,       b int not null       
)

go
create table  dbo.ProcedureWithAlterConstraints_Table
(       a int not null
,       b int constraint CHK_B check ( b is not null) 
,       constraint PK_ProcedureWithAlterConstraints_Table   primary key (a)
,       constraint UN_ProcedureWithAlterConstraints_Table   unique (b)
,       constraint FK_ProcedureWithAlterConstraints_Table   foreign key (b) references dbo.ProcedureWithAlterConstraints_Parent_Table(a)
)
go

create procedure  dbo.[ProcedureWithAlterConstraints_proc]
as
begin
alter table  DBO.PROCEDUREWITHALTERCONSTRAINTS_TABLE nocheck constraint chk_b
end;
go