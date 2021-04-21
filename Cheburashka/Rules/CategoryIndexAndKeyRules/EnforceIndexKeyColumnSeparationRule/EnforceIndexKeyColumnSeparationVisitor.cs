using System.Collections.Generic;
using Microsoft.Data.Schema.ScriptDom.Sql;
//using System.Diagnostics;
using System;
using System.IO;
using System.Text.RegularExpressions;


namespace CallCreditStandards
{
    internal class EnforceIndexKeyColumnSeparationVisitor : TSqlConcreteFragmentVisitor
    {
        private List<TSqlFragment> _objects;

        #region ctor
        public EnforceIndexKeyColumnSeparationVisitor()
        {
            _objects = new List<TSqlFragment>();
        }
        #endregion

        #region properties
        public List<TSqlFragment> Objects
        {
            get { return _objects; }
        }
        #endregion

        #region overrides
        public override void ExplicitVisit(TSqlFragment node)
        {
            if (node.FirstTokenIndex != null)
            {
                _objects.Add(node);
            }
        }

        #endregion

    }


}