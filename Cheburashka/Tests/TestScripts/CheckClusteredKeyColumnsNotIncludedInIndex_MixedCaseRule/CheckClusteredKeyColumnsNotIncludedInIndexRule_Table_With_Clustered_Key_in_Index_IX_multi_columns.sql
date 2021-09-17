CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns
(       a int not null
,       b int not null
,       c int     null
,       d int     null
) ;
GO
create CLUSTERED INDEX ixc_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns (a,b) ;
go
--problem
create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns (c,b,a) ;
go
--no problem
create index ixd_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns (a,d) ;
go
-- no problem
create index ixcd_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_multi_columns (c,d) ;
go

