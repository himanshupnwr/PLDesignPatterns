﻿using MyShop.Domain;

namespace MyShop.Infrastructure.Repositories
{
    internal class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext context) : base(context)
        {

        }
        public override Product Update(Product entity)
        {
            var product = context.Products.Single(p => p.ProductId == entity.ProductId);

            product.Price = entity.Price;
            product.Name = entity.Name;

            return base.Update(product);
        }
    }
}
