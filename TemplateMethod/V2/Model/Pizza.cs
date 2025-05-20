using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.V2.Model
{
    public class Pizza : PanFood
    {
        public string CrustType { get; set; } = "no crust";
        public int NumSlices { get; set; } = 1;
        public List<string> Toppings { get; private set; } = new List<string>();
        public bool WasBaked { get; set; }
    }
}
