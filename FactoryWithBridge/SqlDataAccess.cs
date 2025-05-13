using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    // Refined Abstraction for Data Access
    public class SqlDataAccess : DataAccess
    {
        public SqlDataAccess(IDatabaseImplementation databaseImplementation)
            : base(databaseImplementation) { }

        public override void ExecuteQuery(string query)
        {
            _databaseImplementation.Connect();
            _databaseImplementation.Execute(query);
        }
    }
}
