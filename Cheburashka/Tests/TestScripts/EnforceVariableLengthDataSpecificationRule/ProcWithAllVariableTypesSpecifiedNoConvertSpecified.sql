
CREATE PROCEDURE dbo.ProcWithAllVariableTypesSpecifiedNoConvertSpecified
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

select convert(BINARY       , @Binary            )--   (10)
select convert(CHAR         , @Char              )--   (10)
select convert(Decimal      , @Decimal           )--   (10)
select convert(Float        , @Float             )--   (10)
select convert(NChar        , @NChar             )--   (10)
select convert(Numeric      , @Numeric           )--   (10)
select convert(NVarChar     , @NVarChar          )--   (10)
select convert(VarBinary    , @VarBinary         )--   (10)
select convert(VarChar      , @VarChar           )--   (10)

END