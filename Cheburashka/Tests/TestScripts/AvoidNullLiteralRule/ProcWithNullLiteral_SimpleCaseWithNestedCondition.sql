-- this doesn't build in the mode for whatever reason - but is valid sql whihc should be handled

CREATE procedure ProcWithNullLiteral_SimpleCase
as
BEGIN
DECLARE @b INT = 2
    SELECT a
    FROM dbo.table1
    WHERE case a  when 1 then 'one'
	              when 2 then 'two'
				  when case @b   when 1 then 9
								when 2 then 8
								when null then 7
				  end    then 'null'
		  end = 'one'
end