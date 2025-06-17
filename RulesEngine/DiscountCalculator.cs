namespace RulesEngine
{

    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }

    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.DateOfBirth.HasValue)
            {
                return .15m;
            }
            return 0;
        }
    }

    public class LoyalCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    return .15m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    return .12m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    return .10m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
                {
                    return .08m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    return .05m;
                }
            }
            return 0;
        }
    }
    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.IsVeteran)
            {
                return .10m;
            }
            return 0;
        }
    }
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }
            return 0;
        }
    }

    public class BirthdayRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue && customer.DateOfBirth.Value.Month == DateTime.Today.Month && customer.DateOfBirth.Value.Day == DateTime.Today.Day;

            if (isBirthday) return currentDiscount + 0.10m;
            return currentDiscount;
        }
    }

    public class DiscountRuleEngine
    {
        List<IDiscountRule?> _rules = new List<IDiscountRule?>();
        public DiscountRuleEngine(IEnumerable<IDiscountRule?> rules)
        {
            _rules.AddRange(rules);
        }
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal currentDiscount = 0m;
            foreach(var rule in _rules)
            {
                if (rule != null)
                {
                    currentDiscount = Math.Max(currentDiscount, rule.CalculateDiscount(customer, currentDiscount));
                }
            }
            return currentDiscount;
        }
    }


    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer Customer)
        {
            var ruleType = typeof(IDiscountRule);
            IEnumerable<IDiscountRule?> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(r => Activator.CreateInstance(r) as IDiscountRule);

            var engine = new DiscountRuleEngine(rules);

            return engine.CalculateDiscountPercentage(Customer);
        }
    }
}
