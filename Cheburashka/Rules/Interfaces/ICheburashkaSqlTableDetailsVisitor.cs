using System.Collections.Generic;


namespace Cheburashka
{
    public interface ICheburashkaTableDetailsVisitor
    {
        public IList<TableDetails> TableDetails();
    }
}
