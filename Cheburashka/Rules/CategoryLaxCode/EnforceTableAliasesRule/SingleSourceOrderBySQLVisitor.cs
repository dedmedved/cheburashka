using System.Collections.Generic;
using Microsoft.Data.Schema.ScriptDom.Sql;
using System;
using System.IO;
using System.Linq;

namespace CallCreditStandards
{

    internal class SingleSourceOrderBySQLVisitor : TSqlConcreteFragmentVisitor
    {
        private List<TSqlFragment> _targets;

        #region ctor
        public SingleSourceOrderBySQLVisitor()
        {
            _targets = new List<TSqlFragment>();
        }
        #endregion

        #region properties
        public List<TSqlFragment> SingleSourceOrderBys
        {
            get {  return _targets; }
        }
        #endregion

        #region overrides
        public override void ExplicitVisit(SelectStatement node)
        {
            //if we only have one quep and that has one from clause - its a single source select statement
            List<QuerySpecification> querySpecifications = new List<QuerySpecification>();
            SQLGatherQuery.GetQuery(node, ref querySpecifications);
            if (querySpecifications.Count == 1) {
                if (SqlCheck.HasAtMostOneTableSource(querySpecifications[0]))
                {
                    if ( node.OrderByClause != null ) {
                        _targets.Add(node.OrderByClause);
                    }
                }
            }
            //node.AcceptChildren(this);
        }

        #endregion

    }


}