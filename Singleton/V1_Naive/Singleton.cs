namespace Singleton.V1_Naive
{
    // Bad code
    #nullable enable
    public sealed class Singleton
    {
       private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance Called");
                return _instance ??= new Singleton();
            }
        }

        private Singleton() {
            //cannot be created excpet within this class
            Logger.Log("Constructor invoked");
        }
    }
}
