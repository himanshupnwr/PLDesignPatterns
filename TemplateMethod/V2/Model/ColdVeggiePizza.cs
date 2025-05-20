using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.V2.Model
{
    public class ColdVeggiePizza : PanFood
    {
        public ColdVeggiePizza()
        {
            base.RequiresBaking = false;
        }
    }
}
