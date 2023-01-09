using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal static class DmTableDetailsVisitor
    {
        public static IList<TableDetails> Visit<T>( TSqlFragment sqlFragment, T visitor) where T : TSqlConcreteFragmentVisitor, ICheburashkaTableDetailsVisitor
        {
            sqlFragment.Accept(visitor);
            return visitor.TableDetails();
        }
    }
}
