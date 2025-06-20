﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.SalesTaxStrategy
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var totalPrice = order.TotalPrice;

            if (destination == order.ShippingDetails.OriginCountry.ToLowerInvariant())
            {
                return totalPrice * 0.25m;
            }

            return 0;
        }

        public decimal GetTaxForBetter(Order order)
        {
            decimal totalTax = 0m;

            foreach (var item in order.LineItems)
            {
                switch (item.Key.ItemType)
                {
                    case ItemType.Food:
                        totalTax += (item.Key.Price * 0.06m) * item.Value;
                        break;

                    case ItemType.Literature:
                        totalTax += (item.Key.Price * 0.08m) * item.Value;
                        break;

                    case ItemType.Service:
                    case ItemType.Hardware:
                        totalTax += (item.Key.Price * 0.25m) * item.Value;
                        break;
                }
            }

            return totalTax;
        }
    }
}
