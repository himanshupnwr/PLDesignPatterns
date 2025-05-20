using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SmartProxy
{
    public class DefaultFile : IFile
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}
