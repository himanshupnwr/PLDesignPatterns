namespace Singleton.V1_Naive
{
    // Bad code
    // This implementation of the singleton pattern is naive and not thread safe.
    // multiple threads could enter the if block concurrently, resulting in multiple instantiation of singleton
    // we do not want the constructor getting called more than once, even in multithreaded environment
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

    //singelton uses
    //access to file system
    //access to shared network resource
    //expensive one time configuration
    //at any time only 0 or 1 instance of the singleton class exists in the application
    //singleton classes are created without parameters
    //assume lazy instantiation as the default
    //should have a single private parameterless constructor
    //sealed class
    //a private static field hold the only reference
    //a public static method provides access to this field
} 
