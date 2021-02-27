﻿create TABLE dbo.EnforceForeignKeyRule_TemporalTable_With_FK (a int not NULL
  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforceForeignKeyRule_TemporalTable_With_FK primary KEY (a)
)
WITH (SYSTEM_VERSIONING = on );
GO
create table dbo.EnforceForeignKeyRule_TemporalTable_With_FK_Child (a int not NULL
  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforceForeignKeyRule_TemporalTable_With_FK_Child primary KEY (a)
, constraint FK_EnforceForeignKeyRule_TemporalTable_With_FK foreign key (a) references EnforceForeignKeyRule_TemporalTable_With_FK (a)
)
WITH (SYSTEM_VERSIONING = on );
go