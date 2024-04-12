namespace FactoryMethod.V1_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //V1_Basic Client
            Console.Title = "Factory Method";

            var factories = new List<DiscountFactory> { new CodeDiscountFactory(Guid.NewGuid()), 
                new CountryDiscountFactory("BE") };

            foreach (var factory in factories)
            {
                var discountService = factory.CreateDiscountService();
                Console.WriteLine($"Percentage {discountService.DiscountPercentage} " +
                    $"coming from {discountService}");
            }

            Console.ReadKey();
        }
    }
}
