
CREATE PROCEDURE dbo.ProcWithAllVariableTypesSpecified
AS 
BEGIN
declare  @Binary            BINARY          (10)
,        @Char              CHAR            (10)
,        @Decimal           Decimal         (10)
,        @Float             Float           (10)
,        @NChar             NChar           (10)
,        @Numeric           Numeric         (10)
,        @NVarChar          NVarChar        (10)
,        @VarBinary         VarBinary       (10)
,        @VarChar           VarChar         (10)

,        @Image             Image           
,        @Text              TEXT            
,        @NText             NText           
,        @Bit               BIT
,        @Cursor            Cursor
,        @DateTime          DateTime
,        @DateTime2         DateTime2           
,        @DateTimeOffset    DateTimeOffset      
,        @Int               INT
,        @Money             MONEY
,        @None              None
,        @Real              REAL
,        @SmallDateTime     SMALLDATETIME
,        @SmallInt          SMALLINT
,        @SmallMoney        SmallMoney
,        @Sql_Variant       SQL_VARIANT
,        @Time              TIME
,        @Timestamp         TIMESTAMP
,        @TinyInt           TINYINT
,        @UniqueIdentifier  UniqueIdentifier

declare  @Table             TABLE(a INT)

END