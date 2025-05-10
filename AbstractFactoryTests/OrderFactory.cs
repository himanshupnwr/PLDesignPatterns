using FactoryMethod.SimpleFactory.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryTests
{
    public abstract class OrderFactory
    {
        protected abstract Order CreateOrder();

        public Order GetOrder()
        {
            var order = GetOrder();

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);

            order.LineItems.Add(new Item("CONSULTING", "Build a website", decimal.MaxValue), 1);

            return order;
        }
    }

    public class StandardOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = "Sweden"
                },
                Sender = new Address
                {
                    To = "Someone else",
                    Country = "Sweden"
                }
            };

            return order;
        }
    }

    public class InternationalOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = "Sweden"
                },
                Sender = new Address
                {
                    To = "International Customer",
                    Country = "Denmark"
                }
            };

            return order;
        }
    }
}
