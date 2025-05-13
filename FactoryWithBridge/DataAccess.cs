namespace FactoryWithBridge
{
    public abstract class DataAccess
    {
        protected IDatabaseImplementation _databaseImplementation;

        protected DataAccess(IDatabaseImplementation databaseImplementation)
        {
            _databaseImplementation = databaseImplementation;
        }

        public abstract void ExecuteQuery(string query);
    }
}
