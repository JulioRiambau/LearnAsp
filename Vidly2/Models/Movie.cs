using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public MovieGenre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int MovieGenreId { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime Release { get; set;}

        [Required]
        public DateTime AddedToCatalog { get; set;}

    }
}