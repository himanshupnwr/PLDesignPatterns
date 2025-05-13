using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    // Concrete Implementor for PostgreSQL
    public class PostgreSQLDatabase : IDatabaseImplementation
    {
        public void Connect()
        {
            // PostgreSQL connection logic
            Console.WriteLine("Connected to PostgreSQL Database.");
        }

        public void Execute(string query)
        {
            // PostgreSQL execution logic
            Console.WriteLine($"Executing PostgreSQL Query: {query}");
        }
    }
}
