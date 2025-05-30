namespace Observer
{
    public class Program
    {
        static void Main(string[] args)
        {
            TicketStockService ticketStockService = new TicketStockService();
            TicketResellerService ticketResellerService = new TicketResellerService();
            OrderService orderService = new OrderService();

            //add two observers
            orderService.AddObserver(ticketStockService);
            orderService.AddObserver(ticketResellerService);

            //notify
            orderService.CompleteTicketSale(1, 2);
            Console.ReadKey();

            //remove an observer
            orderService.RemoveObserver(ticketResellerService);

            //notify
            orderService.CompleteTicketSale(2, 4);

            Console.ReadKey();
        }
    }
}
