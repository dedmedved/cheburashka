create proc ProcWithExplicitCollate
as
begin
select * from Table1 where a collate Latin1_General_CI_AS = 'a'
end 
