CREATE PROCEDURE ProcWithBracketedSelfAssignments
AS 
BEGIN
declare @a int = 0;
update TableA
set a = (a+1)             -- picked up
, @a = @a +(1)            -- picked up
set @a=((@a)+1);          -- not picked up
set @a=(@a+1);            -- picked up
set @a=(1+((@a)));        -- not picked up
update TableA
set a = ((a)-(1))         -- not picked up
, @a = ((((@a-1))))       -- picked up
END
