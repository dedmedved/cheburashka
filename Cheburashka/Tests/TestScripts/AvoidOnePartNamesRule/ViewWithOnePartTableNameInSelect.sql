
create view dbo.ViewWithOnePartTableNameInSelect
as
select * from Table1  -- Table1 has no schema. This should be flagged as a problem
