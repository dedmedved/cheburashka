CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndSimilarCoveringIndex 
(       a int           not null
,       b int           not null
,       c int               null
,       d int               null
,       e varchar(20)       null
,       f varchar(200)      null
) ;
go

create  clustered index ix_EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndSimilarCoveringIndex_a_b 
        on dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndSimilarCoveringIndex (a,b)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndSimilarCoveringIndex_a__c 
        ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithClusteredIndexAndSimilarCoveringIndex (a) include(c)
go
