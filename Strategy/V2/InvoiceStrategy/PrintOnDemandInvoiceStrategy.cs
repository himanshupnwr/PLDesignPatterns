using System.Text.Json;

namespace Strategy.V2.InvoiceStrategy
{
    internal class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonSerializer.Serialize<Order>(order);

                client.BaseAddress = new Uri("https://pluralsight.com");

                client.PostAsync("/print-on-demand", new StringContent(content));

                Console.WriteLine($"Invoice sent for printing");
            }
        }
    }
}