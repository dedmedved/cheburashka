create table  dbo.ProcedureWithAlterColumn_Table
(       a int not null
,       b int 
)
go

create procedure  dbo.[ProcedureWithAlterColumn_proc]
as
begin
alter table  dbo.PROCEDUREWITHALTERCOLUMN_TABLE alter COLUMN B CHAR(1) NOT null;        --error this is in the model can't change
alter table  PROCEDUREWITHALTERCOLUMN_TABLE alter COLUMN B CHAR(1) NOT null;            --error no schema given default to dbo

ALTER table  dbo.non_declared_table ADD newcolumn INT;      -- shouldn't raise an error - this table isn't in the model

alter table  #temp_table ADD newcolumn INT;      -- shouldn't raise an error - this table isn't in the model

end;
go