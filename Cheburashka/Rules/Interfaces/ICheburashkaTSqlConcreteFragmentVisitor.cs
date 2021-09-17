using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public interface ICheburashkaTSqlConcreteFragmentVisitor
    {
        public IList<TSqlFragment> SqlFragments();
    }
}
