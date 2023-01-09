CREATE PROCEDURE ProcWithSelectTop1
AS 
BEGIN
select top 1 b from TableA order by b;
select top 10 b from TableA order by b;
select top 1 percent b from TableA order by b;
select top 1 b from TableA order by c;
select (select top 1 b from TableA order by b);
select (select top 10 b from TableA order by b);
select (select top 1 percent b from TableA order by b);
select (select top 1 b from TableA order by c);

select top 1 b from TableA order by 1;

END
