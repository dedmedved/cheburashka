
create proc sys.sp_depends              as 
go
create proc sys.sp_help                 as 
go
create proc sys.sp_helpconstraint       as 
go
create proc sys.sp_helpindex            as 
go
create proc sys.sp_helpstats            as 
go
create proc sys.sp_helptext             as 
go
create proc sys.sp_helptrigger          as 
go
create proc sys.sp_recompile            as 
go
create proc sys.sp_refreshview          as 
go
create proc sys.sp_procoption           as 
go
create proc sys.sp_rename               as 
go
create proc sys.sp_sequence_get_range   as 
go
create proc sys.sp_settriggerorder      as 
go
create proc sys.sp_tableoption          as 
go
create proc sys.sp_autostats            as 
go




create procedure dbo.ProcThatUsesSystemSPCallWithTwoPartObjectName  
--none of these should error -  the sp names are NOT excluded by the code, we have smoe assumptoins to revist.
as
exec sys.sp_depends                 'dbo.Table'
exec sys.sp_help                    'dbo.Table'
exec sys.sp_helpconstraint          'dbo.Table'
exec sys.sp_helpindex               'dbo.Table'
exec sys.sp_helpstats               'dbo.Table'
exec sys.sp_helptext                'dbo.Table'
exec sys.sp_helptrigger             'dbo.Table'
exec sys.sp_recompile               'dbo.Table'
exec sys.sp_refreshview             'dbo.Table'
exec sys.sp_procoption              'dbo.ProcThatUsesSystemSPCallWithOnePartObjectName'
exec sys.sp_rename                  'dbo.Table'
exec sys.sp_sequence_get_range      'dbo.Table'
exec sys.sp_settriggerorder         'dbo.Table'
exec sys.sp_tableoption             'dbo.Table'
exec sys.sp_autostats               'dbo.Table'
