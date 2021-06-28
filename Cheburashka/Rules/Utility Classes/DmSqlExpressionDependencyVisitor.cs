using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    static class DmSqlExpressionDependencyVisitor
    {
        public static IList<SQLExpressionDependency> Visit<T>( TSqlFragment sqlFragment, T visitor) where T : TSqlConcreteFragmentVisitor, ICheburashkaSqlExpressionDependencyVisitor
        {
            sqlFragment.Accept(visitor);
            return visitor.SQLExpressionDependencies();
        }
    }
}
