using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.ShippingStrategy
{
    public class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement PostNord Shipping Integration

                Console.WriteLine("Order is shipped with PostNord");
            }
        }
    }
}
