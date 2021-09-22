CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK
(       A int not null
,       B int     null
,       C int     null
,       D int     null
,       constraint pk_CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column PRIMARY key clustered (a) 
) ;
GO

create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_PK (b,a) ;
go

