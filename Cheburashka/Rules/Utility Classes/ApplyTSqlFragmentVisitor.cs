using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    static class ApplyTSqlFragmentVisitor
    {
        public static IList<TSqlFragment> Visit<T>( TSqlFragment sqlFragment, T visitor) where T : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
        {
            sqlFragment.Accept(visitor);
            return visitor.SqlFragments();
        }
    }
}
