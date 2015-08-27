using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteMovimentoJovem.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("ConnectionString")
        {

        }

        public DbSet<Home> home { get; set; }
        public DbSet<Tipo> tipo { get; set; }
    }
}