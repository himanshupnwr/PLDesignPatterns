namespace Singleton.V2_Lock
{
    // Bad code
    #nullable enable
    public sealed class Singleton
    {
        private static Singleton? _instance;
        private static readonly object padlock = new object();

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance Called");
                lock (padlock) //this lock is used on every reference to singleton
                {
                    return _instance ??= new Singleton();
                }
            }
        }

        private Singleton() {
            //cannot be created excpet within this class
            Logger.Log("Constructor invoked");
        }
    }
}
