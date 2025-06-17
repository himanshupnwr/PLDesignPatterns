using RulesEngine;

namespace RuleEngine.Tests
{
    public class DiscountCalculatorTests
    {
        private DiscountCalculator _calculator = new DiscountCalculator();
        const int DEFAULT_AGE = 30;

        [Fact]
        public void Returns0PctForBasicCustomer()
        {
            var customer = CreateCustomer(DEFAULT_AGE, DateTime.Today.AddDays(-1));

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0m, result);
        }

        [Fact]
        public void Returns5PctForCustomersOver65()
        {
            var customer = CreateCustomer(65, DateTime.Today.AddDays(-1));

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.05m, result);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(70)]
        public void Returns15PctForCustomerFirstPurchase(int customerAge)
        {
            var customer = CreateCustomer(customerAge);

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.15m, result);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(70)]
        public void Returns10PctForCustomersWhoAreVeterans(int customerAge)
        {
            var customer = CreateCustomer(customerAge, DateTime.Today.AddDays(-1));
            customer.IsVeteran = true;

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.10m, result);
        }

        [Theory]
        [InlineData(1, .05)]
        [InlineData(2, .08)]
        [InlineData(5, .10)]
        [InlineData(10, .12)]
        [InlineData(15, .15)]
        public void ReturnsCorrectLoyaltyDiscountForLongtimeCustomers(int yearsAsCustomer, decimal expectedDiscount)
        {
            var customer = CreateCustomer(DEFAULT_AGE,
                DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(expectedDiscount, result);
        }

        [Theory]
        [InlineData(1, .15)]
        [InlineData(2, .18)]
        [InlineData(5, .20)]
        [InlineData(10, .22)]
        [InlineData(15, .25)]
        public void ReturnsCorrectLoyaltyDiscountForLongtimeCustomersOnTheirBirthday(int yearsAsCustomer, decimal expectedDiscount)
        {
            var customer = CreateBirthdayCustomer(DEFAULT_AGE, DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(expectedDiscount, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReturnsVeteransDiscountForLoyal1And2YearCustomers(int yearsAsCustomer)
        {
            var customer = CreateCustomer(DEFAULT_AGE,
                DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));
            customer.IsVeteran = true;

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.10m, result);        
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReturnsVeteransDiscountForLoyal1And2YearCustomersOnBirthday(int yearsAsCustomer)
        {
            var customer = CreateBirthdayCustomer(DEFAULT_AGE,
                DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));
            customer.IsVeteran = true;

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.20m, result);
        }

        [Fact]
        public void Returns10PctForCustomerSecondPurchaseOnBirthday()
        {
            var customer = CreateBirthdayCustomer(20, DateTime.Today.AddDays(-1));

            var result = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(.10m, result);
        }

        private Customer CreateCustomer(int age = DEFAULT_AGE, DateTime? firstPurchaseDate = null)
        {
            return new Customer
            {
                DateOfBirth = DateTime.Today.AddYears(-age).AddDays(-1),
                DateOfFirstPurchase = firstPurchaseDate
            };
        }

        private Customer CreateBirthdayCustomer(int age = DEFAULT_AGE, DateTime? firstPurchaseDate = null)
        {
            return new Customer
            {
                DateOfBirth = DateTime.Today.AddYears(-age),
                DateOfFirstPurchase = firstPurchaseDate
            };
        }
    }
}