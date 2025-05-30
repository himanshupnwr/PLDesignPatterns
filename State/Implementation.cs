namespace State
{
    public class BankAccount
    {
        public BankAccountState accountState { get; set; }

        public decimal Balance { get { return accountState.Balance; } }

        public BankAccount()
        {
            accountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            accountState.Deposit(amount);
        }
        public void Withdraw(decimal amount)
        {
            accountState.Withdraw(amount);
        }
    }

    /// <summary>
    /// State
    /// </summary>
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }

    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount}");
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
            //change state to overdrawn when withdrawing results in less than zero
            Balance -= amount;
            if (Balance < 0)
            {
                BankAccount.accountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    public class OverdrawnState : BankAccountState
    {
        public OverdrawnState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount}");
            Balance = amount;
            if (Balance > 0)
            {
                BankAccount.accountState = new RegularState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, cannot withdraw, balance {Balance}");
        }
    }
}
