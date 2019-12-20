CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes 
(       A int not null
,       B int     null
,       C int     null
,       D int     null
) ;
go

create unique index ix_EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes_a_b on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes (a,b)
go
create unique index ix_EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes_b_a ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithTwoIdenticalExceptForOrderingIndexes (b,a)
go
