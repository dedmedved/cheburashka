
CREATE PROCEDURE dbo.ProcWithNoVariableTypesSpecified
AS 
BEGIN
declare  @Binary            BINARY      
,        @Char              CHAR        
,        @Decimal           Decimal     
,        @Float             Float       
,        @NChar             NChar       
,        @Numeric           Numeric     
,        @NVarChar          NVarChar    
,        @VarBinary         VarBinary   
,        @VarChar           VarChar     

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