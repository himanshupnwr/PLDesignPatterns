namespace State
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "State";

            BankAccount account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(500);
            account.Withdraw(100);

            //deposit enough to go to gold
            account.Deposit(2000);
            //should be in gold now
            account.Deposit(100);
            //back to overdraw
            account.Withdraw(3000);
            //should transition to regular
            account.Deposit(3000);
            //should still be in regular
            account.Deposit(100);
            Console.ReadKey();
        }
    }
}
