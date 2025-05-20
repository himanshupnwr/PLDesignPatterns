namespace Strategy.V1
{
    public interface IExportStrategy
    {
        void Export(Order order);
    }

    public class JsonExportStrategy : IExportStrategy
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json");
        }
    }

    public class CSVExportStrategy : IExportStrategy
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json");
        }
    }

    // Context
    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IExportStrategy? ExportStrategy { get; set; }

        public Order(string customer, int amount, string name, IExportStrategy exportStrategy)
        {
            Customer = customer;
            Amount = amount;
            Name = name;
            ExportStrategy = exportStrategy;
        }

        public void Export()
        {
            ExportStrategy.Export(this);
        }
    }
}
