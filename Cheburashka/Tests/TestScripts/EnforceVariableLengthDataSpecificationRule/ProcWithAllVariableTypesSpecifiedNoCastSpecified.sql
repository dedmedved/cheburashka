
CREATE PROCEDURE dbo.ProcWithAllVariableTypesSpecifiedNoCastSpecified
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

select cast(@Binary          as  BINARY       )--   (10)
select cast(@Char            as  CHAR         )--   (10)
select cast(@Decimal         as  Decimal      )--   (10)
select cast(@Float           as  Float        )--   (10)
select cast(@NChar           as  NChar        )--   (10)
select cast(@Numeric         as  Numeric      )--   (10)
select cast(@NVarChar        as  NVarChar     )--   (10)
select cast(@VarBinary       as  VarBinary    )--   (10)
select cast(@VarChar         as  VarChar      )--   (10)

END