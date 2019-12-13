CREATE TABLE dbo.CheckUniqueIndexHasNoNullColumnsRule_Table_Without_Null_Column 
(       A int not null
,       B int not null
,       C int     null
,       D int     null
) ;
GO
create unique index ix_CheckUniqueIndexHasNoNullColumnsRule_Table_Without_Null_Column on dbo.CheckUniqueIndexHasNoNullColumnsRule_Table_Without_Null_Column (a,b)