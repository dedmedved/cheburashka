﻿CREATE TABLE dbo.CheckUniqueConstraintHasNoNullColumnsRule_Table_Without_Null_Column 
(       A int not null
,       B int not null
,       C int     null
,       D int     null
,       constraint un_CheckUniqueConstraintHasNoNullColumnsRule_Table_Without_Null_Column unique (a,b) 
) ;
GO
