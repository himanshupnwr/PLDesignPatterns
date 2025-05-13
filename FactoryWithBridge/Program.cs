using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create MySQL Data Access
            DataAccess mySqlDataAccess = DataAccessFactory.CreateDataAccess("mysql");
            mySqlDataAccess.ExecuteQuery("SELECT * FROM Users");

            // Create PostgreSQL Data Access
            DataAccess postgreSqlDataAccess = DataAccessFactory.CreateDataAccess("postgresql");
            postgreSqlDataAccess.ExecuteQuery("SELECT * FROM Customers");
        }
    }
}
