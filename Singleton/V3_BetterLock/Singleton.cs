namespace Singleton.V3_BetterLock
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
                //we get a performance benefit by this extra if check as we do not have to check lock every time
                Logger.Log("Instance Called");
                if(_instance == null)
                {
                    lock (padlock) //this lock is used on every reference to singleton
                    {
                        return _instance ??= new Singleton();
                    }
                }
                return _instance;
            }
        }

        private Singleton() {
            //cannot be created excpet within this class
            Logger.Log("Constructor invoked");
        }
    }
}
