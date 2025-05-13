using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    // Concrete Implementor for MySQL
    public class MySQLDatabase : IDatabaseImplementation
    {
        public void Connect()
        {
            // MySQL connection logic
            Console.WriteLine("Connected to MySQL Database.");
        }

        public void Execute(string query)
        {
            // MySQL execution logic
            Console.WriteLine($"Executing MySQL Query: {query}");
        }
    }
}
