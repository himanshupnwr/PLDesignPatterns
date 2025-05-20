using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.ShippingStrategy
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement DHL Shipping Integration

                Console.WriteLine("Order is shipped with DHL");
            }
        }
    }
}
