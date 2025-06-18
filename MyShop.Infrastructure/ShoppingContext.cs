using Microsoft.EntityFrameworkCore;
using MyShop.Domain;

namespace MyShop.Infrastructure
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=orders.db");

            //USeLazyLoadingProxies() - lazy load things like
            //the customer or the order line items.
            //So this here just automatically introduced the behavior
            //for things in the database and entities that are
            //referenced on our order automatically.
            //We didn't have to eagerly load data,
            //but this lazy load pattern allows us to now get
            //proxies back from our repository.
            //So if we now proceed to request a customer,
            //for instance, or the line items on the order,
            //that would go ahead and query the database for that particular data.
            //So this year just automatically introduced the lazy
            //load pattern on our data layer.
            //So we have great flexibility in our applications where we want to introduce these different patterns and practices.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Ignore(c => c.ProfilePicture);
            //modelBuilder.Entity<Customer>()
            //    .Ignore(c => c.ProfilePictureValueHolder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
