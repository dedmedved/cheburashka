using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public interface ICheburashkaTSqlConcreteFragmentVisitor
    {
        void ExplicitVisit(SelectScalarExpression node);
        public IList<TSqlFragment> SqlFragments();
    }
}
