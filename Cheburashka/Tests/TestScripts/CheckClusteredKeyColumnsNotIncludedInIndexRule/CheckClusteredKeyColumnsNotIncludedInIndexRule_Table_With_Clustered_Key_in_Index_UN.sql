﻿CREATE TABLE dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN
(       a int not null
,       b int     null
,       c int     null
,       d int     null
,       constraint un_CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column unique clustered (a) 
) ;
GO

create index ix_CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN
on dbo.CheckClusteredKeyColumnsNotIncludedInIndexRule_Table_With_Clustered_Key_in_Index_UN (b,a) ;
go

