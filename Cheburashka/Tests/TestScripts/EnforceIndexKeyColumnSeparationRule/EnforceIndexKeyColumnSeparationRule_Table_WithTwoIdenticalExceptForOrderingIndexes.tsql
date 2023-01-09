CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes 
(       a int not null primary key
,       b int     null
,       c int     null
,       d int     null
) ;
go

create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes_a_b on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes (a,b)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes_b_a ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes (b,a)
go
