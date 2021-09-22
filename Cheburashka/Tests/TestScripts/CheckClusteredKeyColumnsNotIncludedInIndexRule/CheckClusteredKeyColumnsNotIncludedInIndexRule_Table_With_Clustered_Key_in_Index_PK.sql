CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK
(       a int not null
,       b int     null
,       c int     null
,       d int     null
,       constraint pk_CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column PRIMARY key clustered (a) 
) ;
GO

create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK (b,a) ;
go

