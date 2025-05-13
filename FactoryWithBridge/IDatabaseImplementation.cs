using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWithBridge
{
    // Implementor
    public interface IDatabaseImplementation
    {
        void Connect();
        void Execute(string query);
    }
}
