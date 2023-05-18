using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Data;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        //public List<Customer> customers = new List<Customer>()
        //{
        //    new Customer { Id = 1, Name = "julio"},
        //    new Customer { Id = 2, Name = "antonio"},
        //};

        //public List<Customer> customers = new List<Customer>();

        private Vidly2Context _context;

        public CustomersController()
        {
            _context = new Vidly2Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewCustomers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(viewCustomers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}