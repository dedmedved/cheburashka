CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndNonSimilarCoveringIndex 
(       a int           not null
,       b int           not null
,       c int               null
,       d int               null
,       e varchar(20)       null
,       f varchar(200)      null
) ;
go

alter table dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndNonSimilarCoveringIndex 
add constraint ix_EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndNonSimilarCoveringIndex_a_b 
unique (a,b)
go

create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndNonSimilarCoveringIndex_b__c 
        ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndNonSimilarCoveringIndex (b) include(c)
go
