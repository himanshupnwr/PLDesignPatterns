using FactoryMethod.SimpleFactory;

namespace AbstractFactoryTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FinalizeOrderWithoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var cart = new ShoppingCart(order, null);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }
    }
}