CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder (a INT NOT null
, b INT NOT null
, CONSTRAINT PK_EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder primary KEY (a,b)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder_Child (a INT NOT null
, b INT NOT null
, c INT 
, constraint FK_EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder foreign key (a,b) references EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder (a,b)
)
GO
CREATE CLUSTERED INDEX cix_EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder on EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder_Child(c,b)
GO 
CREATE UNIQUE INDEX ix_EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder_01 on EnforceForeignKeyIsIndexedRule_Table_With_ColumnsSplitBetweenIndexAndClusteredIndexInWrongOrder_Child(a)
GO

-- The fact the clustered keys are in the wrong order kind of doesn't matter as they behave more like included columns in this context.
-- which is kind of okay except we don't currently extend the same logic to included columns per se.