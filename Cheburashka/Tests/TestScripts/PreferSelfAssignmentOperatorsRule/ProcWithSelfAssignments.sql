CREATE PROCEDURE ProcWithSelfAssignments
AS 
BEGIN
declare @a int = 0;
update TableA
set a = a+1             -- picked up
, @a = @a +1            -- picked up

set @a=@a+1;            -- picked up
set @a+=1;              -- not picked up
set @a=1+@a;            -- picked up
set @a=1-@a;            -- not picked up

set @a=@a % 1;          -- not picked up (yet) mod operator is ignored

update TableA
set a = a-1             -- picked up
, @a = @a-1             -- picked up
, a = 1-a               -- not picked up
, @a = 1-@a             -- not picked up

END