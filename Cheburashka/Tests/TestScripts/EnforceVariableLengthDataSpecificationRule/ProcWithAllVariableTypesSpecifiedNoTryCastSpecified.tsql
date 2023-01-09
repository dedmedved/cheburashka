
CREATE PROCEDURE dbo.ProcWithAllVariableTypesSpecifiedNoTryCastSpecified
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

select try_cast(@Binary          as  BINARY       )--   (10)
select try_cast(@Char            as  CHAR         )--   (10)
select try_cast(@Decimal         as  Decimal      )--   (10)
select try_cast(@Float           as  Float        )--   (10)
select try_cast(@NChar           as  NChar        )--   (10)
select try_cast(@Numeric         as  Numeric      )--   (10)
select try_cast(@NVarChar        as  NVarChar     )--   (10)
select try_cast(@VarBinary       as  VarBinary    )--   (10)
select try_cast(@VarChar         as  VarChar      )--   (10)

END