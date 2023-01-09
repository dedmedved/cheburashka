create table dbo.[CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_2_FK] (a int
, CONSTRAINT [PK_CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_2_FK] primary KEY (a)
)
go
create table dbo.CheckMultipleForeignKeysBetweenSameTablesRule_Table_Without_FK_Child (a INT,b int
, constraint FK_CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_FK_1 foreign key (a) references [CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_2_FK] (a)
, constraint FK_CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_FK_2 foreign key (b) references [CheckMultipleForeignKeysBetweenSameTablesRule_Table_With_2_FK] (a)
)
go