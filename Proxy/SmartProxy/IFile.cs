using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SmartProxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
