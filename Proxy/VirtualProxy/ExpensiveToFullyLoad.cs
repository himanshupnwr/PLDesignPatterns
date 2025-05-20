using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.VirtualProxy
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }
        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }

        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
    }
}
