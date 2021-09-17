CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN_unnamed_constraint
(       a int not null unique clustered (a)
,       b int     null
,       c int     null
,       d int     null
) ;
GO

create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN_unnamed_constraint
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN_unnamed_constraint (b,a) ;
go

