create table  dbo.ProcedureWithAddColumn_Table
(       a int not null
,       b int 
)
go

create procedure  dbo.[ProcedureWithAddColumn_proc]
as
begin
alter table  dbo.ProcedureWithAddColumn_Table ADD c INT;        --error this is in the model can't change
alter table  ProcedureWithAddColumn_Table ADD d INT;            --error no schema given default to dbo

alter table  dbo.non_declared_table ADD newcolumn INT;      -- shouldn't raise an error - this table isn't in the model

alter table  #temp_table ADD newcolumn INT;      -- shouldn't raise an error - this table isn't in the model

end;
go