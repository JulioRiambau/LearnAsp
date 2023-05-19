using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

using Vidly2.Data;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {

        private Vidly2Context _context;

        public MoviesController()
        {
            _context = new Vidly2Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "julio"},
                new Customer { Id=2, Name = "antonio"},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers,
                //Customers = new List<Customer>(),
            };

            return View(viewModel);
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            var viewMovies = _context.Movies.Include(c => c.Genre).ToList();

            return View(viewMovies);
        }

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(c => c.Genre).FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}