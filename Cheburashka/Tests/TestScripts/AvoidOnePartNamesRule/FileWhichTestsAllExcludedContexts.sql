
-- Nothing in this file should cause a problem 
--use a;
--go 

create type dbo.MyVType from  varchar(11) not null;
go

create type dbo.MyTType as table 
( LocationName varchar(50)
, CostRate int );
go

create procedure dbo.TestTypes
as
begin
    declare @v01 dbo.MyVType        -- not working as expected.
    ,       @v02 dbo.MyTType
    ,       @v11 bigint
    ,       @v12 binary
    ,       @v13 bit
    ,       @v14 char
    ,       @v15 cursor
    ,       @v16 date
    ,       @v17 datetime
    ,       @v18 datetime2
    ,       @v19 datetimeoffset
    ,       @v20 decimal
    ,       @v21 float
    --,       @v22 geography
    --,       @v23 geometry
    ,       @v24 hierarchyid
    ,       @v25 image
    ,       @v26 int
    ,       @v27 money
    ,       @v28 nchar
    --,       @v29 none
    ,       @v30 ntext
    ,       @v31 numeric
    ,       @v32 nvarchar
    ,       @v33 real
    ,       @v34 rowversion
    ,       @v35 smalldatetime
    ,       @v36 smallint
    ,       @v37 smallmoney
    ,       @v38 sql_variant
    ,       @v39 sysname
--,           @v40 table ( a int )
    ,       @v51 text
    ,       @v52 time
    ,       @v53 tinyint
    ,       @v54 uniqueidentifier
    ,       @v55 varbinary
    ,       @v56 varchar
    ,       @v57 xml
end
go

--use master;
--go
--create proc dbo.xp_cmdshell as
--go
--use msdb;
--go
--create proc dbo.sp_executesql as
--go
--
--use a;
--go

--create view sysmembers as select 1 as a;
--go

create procedure dbo.TestMasterAndMsdbCallsAndSystemNames
as
begin
    declare @v varchar(100) = 'dir /p'
    --exec master..xp_cmdshell @v
    --exec msdb..sp_executesql @v

    select * from sys.sysmembers

end

go

create trigger dbo.i_Table1
on dbo.Table1
after insert,update,delete 
as
begin

select * from dbo.Table1
select * from Inserted
select * from Deleted

end

go


create procedure dbo.TestCTENamesInContext
as
begin

; with a as (
    select * from dbo.Table1
)
select * from a

; with a as (
    select * from dbo.Table1
)
delete a

; with a as (
    select * from dbo.Table1
)
insert into a values(1)

; with a as (
    select * from dbo.Table1
)
merge into dbo.Table1 as b
using a
on a.a = b.a
when matched then update set a = 1
when  not matched by target then insert (a) values(a.a)
;
end

go


---- now test commands that dont use 2 part names

CREATE MESSAGE TYPE
    [//Adventure-Works.com/Expenses/SubmitExpense]
    VALIDATION = WELL_FORMED_XML ;   
go
ALTER MESSAGE TYPE
    [//Adventure-Works.com/Expenses/SubmitExpense]
    VALIDATION = WELL_FORMED_XML ;
go

CREATE MESSAGE TYPE
    [//Adventure-Works.com/Expenses/ExpenseApprovedOrDenied]         
    VALIDATION = WELL_FORMED_XML ;         
go
CREATE MESSAGE TYPE         
    [//Adventure-Works.com/Expenses/ExpenseReimbursed]         
    VALIDATION= WELL_FORMED_XML ;         
go
CREATE CONTRACT          
    [//Adventure-Works.com/Expenses/ExpenseSubmission]         
    ( [//Adventure-Works.com/Expenses/SubmitExpense]         
          SENT BY INITIATOR,         
      [//Adventure-Works.com/Expenses/ExpenseApprovedOrDenied]         
          SENT BY TARGET,         
      [//Adventure-Works.com/Expenses/ExpenseReimbursed]         
          SENT BY TARGET         
    ) ;
go

CREATE ROUTE TransportRoute
    WITH ADDRESS = 'TRANSPORT' ;
go
ALTER ROUTE ExpenseRoute
   WITH 
     BROKER_INSTANCE = 'D8D4D268-00A3-4C62-8F91-634B89B1E317',
     ADDRESS = 'TCP://www.Adventure-Works.com:1234';
go

create proc dbo.run_sb as
begin
DECLARE @dialog_handle UNIQUEIDENTIFIER ;

BEGIN DIALOG CONVERSATION @dialog_handle
   FROM SERVICE [//Adventure-Works.com/ExpenseClient]
   TO SERVICE '//Adventure-Works.com/Expenses'
   ON CONTRACT [//Adventure-Works.com/Expenses/ExpenseSubmission] ;
end
go

create proc dbo.end_sb as
begin
DECLARE @dialog_handle UNIQUEIDENTIFIER ;
END CONVERSATION @dialog_handle WITH CLEANUP ;
end
go




create proc dbo.converse_sb as
begin
DECLARE @dialog_handle1 UNIQUEIDENTIFIER,
        @dialog_handle2 UNIQUEIDENTIFIER,
        @dialog_handle3 UNIQUEIDENTIFIER,
        @OrderMsg XML ;

SET @OrderMsg = '<xml>1</xml>'

BEGIN DIALOG @dialog_handle1
FROM SERVICE [//InitiatorDB/InitiatorService]
TO SERVICE '//TargetDB1/TargetService'
ON CONTRACT [//AllDBs/OrderProcessing] ;

begin dialog @dialog_handle2
from service [//InitiatorDB/InitiatorService]
to service '//TargetDB2/TargetService'
ON CONTRACT [//AllDBs/OrderProcessing] ;

BEGIN DIALOG @dialog_handle3
FROM SERVICE [//InitiatorDB/InitiatorService]
TO SERVICE '//TargetDB3/TargetService'
ON CONTRACT [//AllDBs/OrderProcessing] ;

SEND ON CONVERSATION (@dialog_handle1, @dialog_handle2, @dialog_handle3)
    MESSAGE TYPE [//AllDBs/OrderMsg]
    (@OrderMsg) ;
end
go

CREATE QUEUE ExpenseQueue WITH STATUS=OFF ;
go
CREATE SERVICE [//Adventure-Works.com/Expenses]
    ON QUEUE [dbo].[ExpenseQueue]
    ([//Adventure-Works.com/Expenses/ExpenseSubmission]) ;
go

ALTER SERVICE [//Adventure-Works.com/Expenses]
    (ADD CONTRACT [//Adventure-Works.com/Expenses/ExpenseSubmission]) ;
go

CREATE BROKER PRIORITY [//Adventure-Works.com/Expenses/BasePriority]
    FOR CONVERSATION
    SET (CONTRACT_NAME = ANY,
         LOCAL_SERVICE_NAME = ANY,
         REMOTE_SERVICE_NAME = ANY,
         PRIORITY_LEVEL = 3);
go

ALTER BROKER PRIORITY SimpleContractDefaultPriority
    FOR CONVERSATION
    SET (PRIORITY_LEVEL = 3);
go

DROP BROKER PRIORITY ConversationPriorityName
go

DROP SERVICE [//Adventure-Works.com/Expenses]
go
DROP ROUTE ExpenseRoute ;
go

CREATE USER APUser WITHOUT LOGIN ;
go

CREATE REMOTE SERVICE BINDING APBinding
    TO SERVICE '//Adventure-Works.com/services/AccountsPayable'
    WITH USER = APUser ;
go
ALTER REMOTE SERVICE BINDING APBinding
    WITH USER = SecurityAccount ;
go
DROP REMOTE SERVICE BINDING APBinding ;
go
DROP CONTRACT 
    [//Adventure-Works.com/Expenses/ExpenseSubmission] ;
go

DROP MESSAGE TYPE [//Adventure-Works.com/Expenses/SubmitExpense] ;
go

CREATE SCHEMA Sprockets AUTHORIZATION dbo
    -- we can just about accept the need for no schema prefix here
    CREATE TABLE NineProngs (souce int, cost int, partnumber int)
    GRANT SELECT ON SCHEMA::Sprockets TO public
go
CREATE TABLE Sprockets.TenProngs (souce int, cost int, partnumber int)
go
-- for some reason this causes an error in the test model
--grant SELECT ON OBJECT::Sprockets.NineProngs TO APUser
go
grant SELECT ON OBJECT::Sprockets.TenProngs TO APUser
go


DROP SCHEMA Sprockets;
go 