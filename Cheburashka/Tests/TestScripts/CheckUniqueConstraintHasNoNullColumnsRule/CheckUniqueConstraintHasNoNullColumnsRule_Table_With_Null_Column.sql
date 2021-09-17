CREATE TABLE dbo.CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
,       constraint un_CheckUniqueConstraintHasNoNullColumnsRule_Table_With_Null_Column unique (a,b) 
) ;
GO
