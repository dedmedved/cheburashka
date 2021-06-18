using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    static class DmTSqlFragmentVisitor
    {
        public static IList<TSqlFragment> Visit<T>( TSqlFragment sqlFragment, T visitor) where T : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
        {
            sqlFragment.Accept(visitor);
            return visitor.SqlFragments();
        }
    }
}
