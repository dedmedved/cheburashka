using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public interface ICheburashkaTSqlConcreteFragmentVisitor
    {
        //public IList<TSqlFragment> SqlFragments => SqlFragments();
        public IList<TSqlFragment> SqlFragments();
    }
}
