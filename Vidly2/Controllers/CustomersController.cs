using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "julio"},
            new Customer { Id = 2, Name = "antonio"},
        };

        //public List<Customer> customers = new List<Customer>();

        // GET: Customers
        public ActionResult Index()
        {
            var viewCustomers = new IndexCustomersViewModel() { Customers = customers };

            return View(viewCustomers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}