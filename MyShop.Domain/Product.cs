﻿namespace MyShop.Domain
{
    public class Product
    {
        public Guid ProductId { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
