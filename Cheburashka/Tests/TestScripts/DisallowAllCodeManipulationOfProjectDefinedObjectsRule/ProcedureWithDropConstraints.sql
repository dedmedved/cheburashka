create table  dbo.[ProcedureWithDropConstraints_Parent_Table]
(       a int not null          primary key
,       b int 
)

go
create table  dbo.[ProcedureWithDropConstraints_Table]
(       a int not null
,       b int                   
,       constraint PK_ProcedureWithDropConstraints_Table   primary key (a)
,       constraint UN_ProcedureWithDropConstraints_Table   unique (b)
,       constraint FK_ProcedureWithDropConstraints_Table   foreign key (b) references dbo.[ProcedureWithDropConstraints_Parent_Table](a)
)
go

create procedure  dbo.[ProcedureWithDropConstraints_proc]
as
begin
alter table  dbo.[ProcedureWithDropConstraints_Table] drop constraint PK_ProcedureWithDropConstraints_Table
alter table  dbo.[ProcedureWithDropConstraints_Table] drop constraint UN_ProcedureWithDropConstraints_Table
alter table  dbo.[ProcedureWithDropConstraints_Table] drop constraint FK_ProcedureWithDropConstraints_Table
end;
go