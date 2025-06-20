using Microsoft.AspNetCore.Mvc;
using MyShop.Domain;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> repository;

        public CustomerController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = repository.GetAll();

                return View(customers);
            }
            else
            {
                var customer = repository.Get(id.Value);

                return View(new[] { customer });
            }
        }

    }
}
