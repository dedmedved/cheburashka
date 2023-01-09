using Microsoft.SqlServer.Dac.Model;

namespace Cheburashka
{
    public struct ColumnDetails {
        public string Name;
        public ObjectIdentifier DataType;
        public bool Nullable;
        public object Expression;
        //public int Length;
        //public int Precision;
    }
}
