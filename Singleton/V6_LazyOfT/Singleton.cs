using System.ComponentModel;
using System.Threading;

namespace Singleton.V6_LazyOfT
{
    // Source: https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        // Lazy<T> when we use lazy the compiler take care of making it therad safe
        // reading this will initialize the instance
        // Lazy Initialization: The instance of the object is not created until it is accessed for the first time.
        // This means that if the Singleton instance is never accessed, it will not be created, which can save resources.
        // When multiple threads attempt to access the Value property of a Lazy<T> instance,
        // it ensures that the instance is created only once, even if multiple threads are trying to access it simultaneously.
        // When you create a Lazy<T> instance, you can specify the thread-safety mode. The default mode is LazyThreadSafetyMode.ExecutionAndPublication, which ensures that:
        // Only one thread can create the instance at a time.
        // If multiple threads try to access the instance simultaneously, only one will create it, while the others will wait for the instance to be created.

        public static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _lazy.Value;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
