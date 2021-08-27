using System.Collections.Generic;


namespace Cheburashka
{
    public interface ICheburashkaSqlExpressionDependencyVisitor
    {
        public IList<SqlExpressionDependency> SqlExpressionDependencies();
    }
}
