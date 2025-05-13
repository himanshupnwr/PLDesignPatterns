using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    // Factory
    public static class DataAccessFactory
    {
        public static DataAccess CreateDataAccess(string dbType)
        {
            IDatabaseImplementation databaseImplementation;

            switch (dbType.ToLower())
            {
                case "mysql":
                    databaseImplementation = new MySQLDatabase();
                    break;
                case "postgresql":
                    databaseImplementation = new PostgreSQLDatabase();
                    break;
                default:
                    throw new ArgumentException("Invalid database type");
            }

            return new SqlDataAccess(databaseImplementation);
        }
    }
}
