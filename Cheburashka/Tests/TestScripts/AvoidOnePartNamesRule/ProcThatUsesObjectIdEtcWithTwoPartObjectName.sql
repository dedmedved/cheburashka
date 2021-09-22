
create procedure dbo.ProcThatUsesObjectIdEtcWithTwoPartObjectName  
as
select object_id('dbo.Table1')              -- has schema name in literal.  This is OK.
select index_col('dbo.Table1',1,1)          -- has schema name in literal.  This is OK.
select type_id('dbo.Table1')                -- has schema name in literal.  This is OK.
