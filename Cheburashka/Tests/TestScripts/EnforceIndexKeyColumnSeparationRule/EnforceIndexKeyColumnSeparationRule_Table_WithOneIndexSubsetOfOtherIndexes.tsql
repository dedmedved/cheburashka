CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexSubsetOfOtherIndexes 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexSubsetOfOtherIndexes_a_b on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexSubsetOfOtherIndexes (a,b)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexSubsetOfOtherIndexes_b ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithOneIndexSubsetOfOtherIndexes (b)
go
