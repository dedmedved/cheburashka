CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndex 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndex_a_b on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndex (a,b)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndex_a ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexARealSubsetOfOtherIndex (a)
go
