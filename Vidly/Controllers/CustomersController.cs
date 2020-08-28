using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System;

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
        public ActionResult New()
        {
            var membershipTypes = applicationDbContext.MembershipType.ToList();
            var customerViewModel = new CustomerViewModel
            {
              MembershipTypes = membershipTypes
            };
            return View("CustomerForm", customerViewModel);
        }


        [HttpPost]
        public ActionResult Save(CustomerViewModel customerViewModel)
        {
            if (! ModelState.IsValid)
            {
                var membershipTypes = applicationDbContext.MembershipType.ToList();
                var _customerViewModel = new CustomerViewModel
                {
                    Customers = new Customer(),
                    MembershipTypes = membershipTypes
                };
                return View("CustomerForm", _customerViewModel);
            }
            var customer = new Customer
            {
              Name = customerViewModel.Customers.Name,
              BirthDayDate  = customerViewModel.Customers.BirthDayDate,
              IsSubscribedToNewsLetter = customerViewModel.Customers.IsSubscribedToNewsLetter,
              MembershipTypeId = Convert.ToByte(customerViewModel.MembershipTypeId)
            };
            if(customerViewModel.Customers.Id == 0)
            {
                applicationDbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = applicationDbContext.Customers.Single(c => c.Id == customerViewModel.Customers.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDayDate = customer.BirthDayDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = applicationDbContext.Customers.Include(c =>c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            var customerViewModel = new CustomerViewModel
            {
                Customers = customer,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipTypes = applicationDbContext.MembershipType.ToList()
            };

            return View("CustomerForm", customerViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }

    }
}