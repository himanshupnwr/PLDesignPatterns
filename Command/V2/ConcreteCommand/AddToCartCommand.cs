﻿using Command.V2.Command;
using Command.V2.Model;
using Command.V2.Repository;

namespace Command.V2.ConcreteCommand
{
    public class AddToCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public AddToCartCommand(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            if (product == null) return false;

            return productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Execute()
        {
            if (product == null) return;

            productRepository.DecreaseStockBy(product.ArticleId, 1);

            shoppingCartRepository.Add(product);
        }

        public void Undo()
        {
            if (product == null) return;

            var lineItem = shoppingCartRepository.Get(product.ArticleId);

            productRepository.IncreaseStockBy(product.ArticleId, lineItem.Quantity);

            shoppingCartRepository.RemoveAll(product.ArticleId);
        }
    }
}
