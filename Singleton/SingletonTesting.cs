using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonTesting
    {
        private readonly V6_LazyOfT.Singleton _singleton;
        private readonly IServiceThatSingletonImplements _singleton2;

        // Dependency Injection is OK
        public SingletonTesting(V6_LazyOfT.Singleton singleton)
        {
            _singleton = singleton;
        }

        // interface is even better
        public SingletonTesting(IServiceThatSingletonImplements singleton)
        {
            _singleton2 = singleton;
        }
        // Method argument is OK
        public void DoSomething1(V6_LazyOfT.Singleton singleton)
        {
            // do something with the singleton instance
        }

        // Interface is better still
        public void DoSomething1(IServiceThatSingletonImplements singleton)
        {
            // do something with the singleton instance
        }
        // Static access is problematic
        public void DoSomething2()
        {
            // Do some logic

            // This makes it very difficult to unit test this method
            // This is an example of Static Cling code smell
            // See Refactoring for C# course
            // v6.Singleton.Instance.SaveToDatabase(data);

            // Do some other logic
        }
    }

    public interface IServiceThatSingletonImplements
    { }
}
