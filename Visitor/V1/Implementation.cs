using System.ComponentModel;

namespace Visitor.V1
{
    /// <summary>
    /// Concrete Element
    /// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Customer(string name, decimal amountOrdered)
        {
            Name = name;
            AmountOrdered = amountOrdered;
        }

        public void Accept(IVisitor visitor)
        {
            //visitor.VisitCustomer(this);
            visitor.Visit(this);
            Console.WriteLine($"Visisted {nameof(Customer)} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// Concrete Element
    /// </summary>
    public class Employee : IElement
    {
        public int YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(string name, int yearsEmployed)
        {
            Name = name;
            YearsEmployed = yearsEmployed;
        }

        public void Accept(IVisitor visitor)
        {
            //visitor.VisitEmployee(this);
            visitor.Visit(this);
            Console.WriteLine($"Visisted {nameof(Employee)} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// Visitor
    /// </summary>
    //public interface IVisitor
    //{
    //    void VisitCustomer(Customer customer);
    //    void VisitEmployee(Employee employee);
    //}

    //Visitor Alternative
    public interface IVisitor
    {
        void Visit(IElement element);
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if (element is Employee)
            {
                VisitEmployee((Employee)element);
            }
        }
        private void VisitCustomer(Customer customer)
        {
            //percentage of total amount
            var discount = customer.AmountOrdered / 10;
            //set it in the customer
            customer.Discount = discount;
            //add it to the total discount
            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            //fixed value depending on the amount of years employed
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            //set it on the employee
            employee.Discount = discount;
            //add it to the total amount
            TotalDiscountGiven += discount;
        }
    }

    /// <summary>
    /// Object structure
    /// </summary>
    public class Container
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Customer> Customers { get; set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach (Employee employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach (Customer customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }
}
