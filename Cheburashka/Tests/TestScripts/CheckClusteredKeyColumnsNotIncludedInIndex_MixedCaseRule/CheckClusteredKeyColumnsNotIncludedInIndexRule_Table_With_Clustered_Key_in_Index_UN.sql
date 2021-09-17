CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN
(       A int not null
,       B int     null
,       C int     null
,       D int     null
,       constraint un_CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column unique clustered (a) 
) ;
GO

create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN (b,a) ;
go

