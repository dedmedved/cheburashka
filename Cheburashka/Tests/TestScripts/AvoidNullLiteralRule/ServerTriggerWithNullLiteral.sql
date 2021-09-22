create trigger [ServerTriggerWithNullLiteral] on ALL SERVER FOR logon
as
begin
    SELECT a
    FROM dbo.table1
    WHERE a = null
end
go
