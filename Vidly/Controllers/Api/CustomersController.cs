using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CustomersController()
        {
            applicationDbContext = new ApplicationDbContext();
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return applicationDbContext.Customers.ToList().
                Select(Mapper.Map<Customer, CustomerDTO>);
        }

        public CustomerDTO GetCustomer(int id)
        {
            var customer = applicationDbContext.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            applicationDbContext.Customers.Add(customer);
            applicationDbContext.SaveChanges();

            customerdto.Id = customer.Id;
            return Created(new Uri (Request.RequestUri + "/" + customer.Id), customerdto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = applicationDbContext.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDb);

            //customerInDb.Name = customer.Name;
            //customerInDb.BirthDayDate = customer.BirthDayDate;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            applicationDbContext.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = applicationDbContext.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            applicationDbContext.Customers.Remove(customerInDb);
            applicationDbContext.SaveChanges();
        }
    }
}
