CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
(       a int not null
,       b int not null
,       c int     null
,       d int     null
) ;
GO
create CLUSTERED INDEX ixc_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (a,b) ;
go
--problem
create index ixCheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (c)  include (b,a);
go
--no problem with index but with included columns
create index ixd_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (a,d) include (b) ;
go
-- no problem with index, but with included columns
create index ixcd_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (c,d) include (a,b) ;
go
-- no problem 
create index ixce_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (c) include (d) ;
go
--no problem with index nor with included columns
create index ixcf_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_IX_included_columns (b) include (c,d) ;
go
