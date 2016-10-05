
create procedure dbo.ProcThatUsesSystemSPCallWithOnePartObjectName  
--all of these should error - note that only the literal name errors - the sp names are excludeded by the code.
as
exec sys.sp_depends                 'Table'
exec sys.sp_help                    'Table'
exec sys.sp_helpconstraint          'Table'
exec sys.sp_helpindex               'Table'
exec sys.sp_helpstats               'Table'
exec sys.sp_helptext                'Table'
exec sys.sp_helptrigger             'Table'
exec sys.sp_recompile               'Table'
exec sys.sp_refreshview             'Table'
exec sys.sp_procoption              'ProcThatUsesSystemSPCallWithOnePartObjectName'
exec sys.sp_rename                  'Table'
exec sys.sp_sequence_get_range      'Table'
exec sys.sp_settriggerorder         'Table'
exec sys.sp_tableoption             'Table'
exec sys.sp_autostats               'Table'
