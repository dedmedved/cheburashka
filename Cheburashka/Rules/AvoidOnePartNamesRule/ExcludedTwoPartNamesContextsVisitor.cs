// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

//------------------------------------------------------------------------------
// <copyright company="DMV">
//   Copyright 2014 Ded Medved
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class ExcludedTwoPartNamesContextsVisitor : TSqlConcreteFragmentVisitor
    {
        public ExcludedTwoPartNamesContextsVisitor()
        {
            ExcludedTwoPartNamesContexts = new List<TSqlFragment>();
        }

        public IList<TSqlFragment> ExcludedTwoPartNamesContexts { get; }

        //OK
        //CREATE APPLICATION ROLE 
        //ALTER APPLICATION ROLE 
        //DROP APPLICATION ROLE 
        //CREATE CREDENTIAL 
        //ALTER CREDENTIAL 
        //DROP CREDENTIAL 
        //CREATE CRYPTOGRAPHIC PROVIDER 
        //ALTER CRYPTOGRAPHIC PROVIDER 
        //DROP CRYPTOGRAPHIC PROVIDER 
        //CREATE DATABASE 
        //ALTER DATABASE 
        //DROP DATABASE 
        //CREATE ENDPOINT 
        //ALTER ENDPOINT 
        //DROP ENDPOINT 
        //CREATE FULLTEXT CATALOG 
        //ALTER FULLTEXT CATALOG 
        //DROP FULLTEXT CATALOG 
        //CREATE FULLTEXT INDEX
        //ALTER FULLTEXT INDEX
        //DROP FULLTEXT INDEX
        //CREATE FULLTEXT STOPLIST 
        //ALTER FULLTEXT STOPLIST 
        //DROP FULLTEXT STOPLIST 
        //CREATE LOGIN 
        //ALTER LOGIN 
        //DROP LOGIN 
        //CREATE USER 
        //ALTER USER 
        //DROP USER 
        //CREATE XML INDEX -- drop and alter follow normal index usage
        //CREATE FULLTEXT INDEX
        //ALTER FULLTEXT INDEX
        //DROP FULLTEXT INDEX
        //CREATE RESOURCE POOL 
        //ALTER RESOURCE POOL 
        //DROP RESOURCE POOL 
        //CREATE INDEX
        //ALTER INDEX
        //DROP INDEX
        //CREATE ASYMMETRIC KEY 
        //ALTER ASYMMETRIC KEY 
        //OPEN ASYMMETRIC KEY 
        //CLOSE ASYMMETRIC KEY 
        //CREATE DATABASE AUDIT SPECIFICATION 
        //ALTER DATABASE AUDIT SPECIFICATION 
        //DROP DATABASE AUDIT SPECIFICATION 
        //CREATE EVENT NOTIFICATION 
        //DROP EVENT NOTIFICATION 
        //CREATE EVENT SESSION 
        //ALTER EVENT SESSION 
        //DROP EVENT SESSION 
        //CREATE PARTITION SCHEME 
        //ALTER PARTITION SCHEME 
        //DROP PARTITION SCHEME 
        //CREATE PARTITION FUNCTION
        //ALTER PARTITION FUNCTION
        //DROP PARTITION FUNCTION
        //CREATE REMOTE SERVICE BINDING 
        //ALTER REMOTE SERVICE BINDING 
        //DROP REMOTE SERVICE BINDING 
        //CREATE SERVER AUDIT 
        //ALTER SERVER AUDIT 
        //DROP SERVER AUDIT 
        //CREATE SERVER AUDIT SPECIFICATION 
        //ALTER SERVER AUDIT SPECIFICATION 
        //DROP SERVER AUDIT SPECIFICATION 
        //CREATE WORKLOAD GROUP 
        //ALTER WORKLOAD GROUP 
        //DROP WORKLOAD GROUP 

        //other stuff
        //CREATE SCHEMA -- probably safe as it is --looks like it can't be in code
        //ALTER SCHEMA -- safe as it is 
        //DROP SCHEMA -- NEEDS ADDING
        //CREATE SPATIAL INDEX  -probably safe as it is
        //CREATE STATISTICS  name only-probably safe as it is

        public override void ExplicitVisit(CreateMessageTypeStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(AlterMessageTypeStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(DropMessageTypeStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(CreateContractStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        // does not exist
        //public override void ExplicitVisit(AlterContractStatement node)
        //{
        //    _targets.Add(node);
        //}
        public override void ExplicitVisit(DropContractStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        //this is ok 
        //public override void ExplicitVisit(CreateQueueStatement  node)
        //public override void ExplicitVisit(AlterQueueStatement  node)
        //public override void ExplicitVisit(DropQueueStatement  node)
        //{
        //    _targets.Add(node);
        //}
        public override void ExplicitVisit(CreateRouteStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(AlterRouteStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(DropRouteStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(BeginDialogStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(SendStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(EndConversationStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(CreateServiceStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        //Queue name needs to be 2 part -!!!
        public override void ExplicitVisit(AlterServiceStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(DropServiceStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(CreateBrokerPriorityStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(AlterBrokerPriorityStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        public override void ExplicitVisit(DropBrokerPriorityStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }

        ///////////////////////////////////////////
        //barfs on user name element
        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        //barfs on user name element
        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        // for consistency - doesn't raise any errors - no user name element
        public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        public override void ExplicitVisit(DropSchemaStatement node)
        {
            ExcludedTwoPartNamesContexts.Add(node);
        }

        ///////////////////////////////////////////
        public override void ExplicitVisit(CreateTriggerStatement node)
        {
            if (node.TriggerObject.TriggerScope != TriggerScope.Normal)
            {
                ExcludedTwoPartNamesContexts.Add(node.Name);
            }
        }
        public override void ExplicitVisit(AlterTriggerStatement node)
        {
            if (node.TriggerObject.TriggerScope != TriggerScope.Normal)
            {
                ExcludedTwoPartNamesContexts.Add(node.Name);
            }
        }
        public override void ExplicitVisit(DropTriggerStatement node)
        {
            if (node.TriggerScope != TriggerScope.Normal)
            {
                foreach (var trigger in node.Objects)
                {
                    ExcludedTwoPartNamesContexts.Add(trigger);
                }
            }
        }
    }
}