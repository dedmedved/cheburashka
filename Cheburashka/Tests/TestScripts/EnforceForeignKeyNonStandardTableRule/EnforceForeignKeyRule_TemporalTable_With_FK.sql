﻿create TABLE dbo.EnforceForeignKeyRule_TemporalTable_With_FK (a int not NULL

  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforceForeignKeyRule_TemporalTable_With_FK primary KEY (a)
)
WITH (SYSTEM_VERSIONING = on (HISTORY_TABLE = dbo.EnforceForeignKeyRule_TemporalTable_With_FKHistory));
GO

create table dbo.EnforceForeignKeyRule_TemporalTable_With_FK_Child (a int not NULL

  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforceForeignKeyRule_TemporalTable_With_FK_Child primary KEY (a)
, constraint FK_EnforceForeignKeyRule_TemporalTable_With_FK foreign key (a) references EnforceForeignKeyRule_TemporalTable_With_FK (a)
)
WITH (SYSTEM_VERSIONING = on (HISTORY_TABLE = dbo.EnforceForeignKeyRule_TemporalTable_With_FK_ChildHistory));
go

-- as of today 23/02/2021 SSDT doesn't support temp/generic system_versioing history tables - ie 
-- a name needs to be given for HISTORY_TABLE