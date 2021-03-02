create TABLE dbo.EnforcePrimaryKeyRule_TemporalTable_With_PK (a int not NULL
  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforcePrimaryKeyRule_TemporalTable_With_PK primary KEY (a)
)
WITH (SYSTEM_VERSIONING = on ( HISTORY_TABLE = [dbo].[EnforcePrimaryKeyRule_TemporalTable_With_PK_History] ) );
GO
create table dbo.EnforcePrimaryKeyRule_TemporalTable_With_PK_Child (a int not NULL
  , SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL
  , SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL
  , PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
, CONSTRAINT PK_EnforcePrimaryKeyRule_TemporalTable_With_PK_Child primary KEY (a)
)
WITH (SYSTEM_VERSIONING = on ( HISTORY_TABLE = [dbo].[EnforcePrimaryKeyRule_TemporalTable_With_PK_Child_History] ) );
go
