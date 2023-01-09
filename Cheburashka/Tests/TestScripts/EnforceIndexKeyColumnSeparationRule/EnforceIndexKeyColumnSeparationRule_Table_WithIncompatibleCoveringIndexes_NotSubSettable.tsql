CREATE TABLE dbo.EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable 
(       a int           not null
,       b int           not null
,       c int               null
,       d int               null
,       e varchar(20)       null
,       f varchar(200)      null
) ;
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable_b__d 
        ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable (b) include(d)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable_b__c 
        ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable (b) include(c)
go
create  index ix_EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable_b_a__c 
        ON dbo.EnforceIndexKeyColumnSeparationRule_Table_WithIncompatibleCoveringIndexes_NotSubSettable (b,a) include(e)
go
