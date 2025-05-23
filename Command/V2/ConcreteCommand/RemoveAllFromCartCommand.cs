using Command.V2.Command;
using Command.V2.Repository;

namespace Command.V2.ConcreteCommand
{
    public class RemoveAllFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        public bool CanExecute()
        {
            return shoppingCartRepository.All().Any();
        }

        public void Execute()
        {
            var items = shoppingCartRepository.All().ToArray(); // Make a local copy

            foreach (var lineItem in items)
            {
                productRepository.IncreaseStockBy(lineItem.Product.ArticleId, lineItem.Quantity);

                shoppingCartRepository.RemoveAll(lineItem.Product.ArticleId);
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
