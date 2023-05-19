using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MovieGenre Genre { get; set; }

        [Required]
        public int MovieGenreId { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        [Required]
        public DateTime Release { get; set;}

        [Required]
        public DateTime AddedToCatalog { get; set;}

    }
}