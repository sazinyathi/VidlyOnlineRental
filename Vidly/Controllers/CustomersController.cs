using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CustomersController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = applicationDbContext.Customers.Include(y => y.MembershipType).ToList();
            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = applicationDbContext.Customers.Include(c =>c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }

    }
}