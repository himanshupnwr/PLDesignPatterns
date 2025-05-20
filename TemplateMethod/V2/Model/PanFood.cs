using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.V2.Model
{
    public abstract class PanFood
    {
        public bool RequiresBaking { get; set; } = true;
    }
}
