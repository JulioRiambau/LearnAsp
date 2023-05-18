using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Data
{
    public class Vidly2Context : DbContext
    {
        public Vidly2Context() : base()
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}