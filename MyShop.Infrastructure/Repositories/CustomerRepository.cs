using MyShop.Domain;
using MyShop.Domain.Lazy;
using MyShop.Infrastructure.Services;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override IEnumerable<Customer> GetAll()
        {
            return base.GetAll().Select(c =>
            {
                c.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
                {
                    return ProfilePictureService.GetFor(c.Name);
                });

                return c;
            });
        }

        public override Customer Update(Customer entity)
        {
            var customer = context.Customers.Single(c => c.CustomerId == entity.CustomerId);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;

            return base.Update(customer);
        }
    }
}
