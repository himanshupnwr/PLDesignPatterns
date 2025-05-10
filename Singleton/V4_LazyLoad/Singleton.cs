using System.ComponentModel;

namespace Singleton.V4_LazyLoad
{
    // Source: https://csharpindepth.com/articles/singleton
    // This approach uses the feature of static type construction
    // c# static constructors only run once per app domain
    // they are called when any static member of a type is referenced
    // make sure you use an explicit static constructor to avoid issue with c# compiler and beforefieldInit
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        // reading this will initialize the _instance
        public static readonly string GREETING = "Hi!";

        // Tell C# compiler not to mark type as beforefieldinit
        // (https://csharpindepth.com/articles/BeforeFieldInit)
        static Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _instance;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
