CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndexButIsColumnStore 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndexButIsColumnStore_a_b on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndexButIsColumnStore (a,b)
go
create columnstore index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndexButIsColumnStore_a ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndexButIsColumnStore (a)
go

--Column store indexs should be ignored fully by all these indexesing rules
--column store indexes are a completely separate type to index in thd DACFX model  -  so we are safe by default.