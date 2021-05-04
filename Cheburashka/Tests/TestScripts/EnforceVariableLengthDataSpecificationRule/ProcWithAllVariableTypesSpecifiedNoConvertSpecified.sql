
CREATE PROCEDURE dbo.ProcWithAllVariableTypesSpecifiedNoTryConvertSpecified
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

select try_convert(BINARY       , @Binary            )--   (10)
select try_convert(CHAR         , @Char              )--   (10)
select try_convert(Decimal      , @Decimal           )--   (10)
select try_convert(Float        , @Float             )--   (10)
select try_convert(NChar        , @NChar             )--   (10)
select try_convert(Numeric      , @Numeric           )--   (10)
select try_convert(NVarChar     , @NVarChar          )--   (10)
select try_convert(VarBinary    , @VarBinary         )--   (10)
select try_convert(VarChar      , @VarChar           )--   (10)

END