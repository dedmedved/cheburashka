CREATE TABLE dbo.EnforceNamedConstraintRule_Table_With_Constraint_Names 
(       a int constraint pk_EnforceNamedConstraintRule_Table_With_Constraint_Names primary key 
,       b int constraint ck_EnforceNamedConstraintRule_Table_With_Constraint_Names check ( b > 0 )
,       c int constraint df_EnforceNamedConstraintRule_Table_With_Constraint_Names default (0)
,       d int constraint fk_EnforceNamedConstraintRule_Table_With_Constraint_Names foreign key references dbo.EnforceNamedConstraintRule_Table_Without_Constraint_Names (a)
) ;
GO
