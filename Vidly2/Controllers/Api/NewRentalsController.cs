using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Vidly2.Data;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalsController: ApiController
    {
        private Vidly2Context _context;

        public NewRentalsController()
        {
            _context = new Vidly2Context();
        }

        // GET /api/newrentals
        public IHttpActionResult GetRentals()
        {
            return Ok(_context.Rentals.AsEnumerable().Select(Mapper.Map<Rental, NewRentalDto>));
        }

        // POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var rentals = new List<Rental>();

            if (newRentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movie ids have been given");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer id is not valid");
            }

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
            {
                return BadRequest("One or more movies not found");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest($"Movie {movie.Name} is not available");
                }

                movie.NumberAvailable--;

                rentals.Add(new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                });
            }

            foreach (var rental in rentals)
            {
                _context.Rentals.Add(rental);
            }
            
            _context.SaveChanges();

            return Ok();
        }
    }
}