
create view ViewWithOnePartTableNameInDefinition -- View name has no schema. This should be flagged as a problem
as
select * from dbo.Table1  
