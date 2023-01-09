using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public struct TableDetails {
        public TableDetails(Identifier T, TableDefinition D)
        {
            TableName = T;
            TableDefinition = D;
        }
        public Identifier TableName { get; set; }
        public TableDefinition TableDefinition  { get; set; } 
    }
}
