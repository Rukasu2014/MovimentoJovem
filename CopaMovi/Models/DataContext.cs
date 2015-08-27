using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using System.Linq;
using System.Web;

namespace CopaMovi.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("ConnectionString")
        {

        }

        public DbSet<Integrantes> Integrantes { get; set; }
        public DbSet<Patrocinador> Patrocinador { get; set; }
        public DbSet<Time> Time { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "ID").Configure(p=>p.IsKey());
            modelBuilder.Properties<string>().Configure(p=>p.HasColumnType("VARCHAR"));
            modelBuilder.Properties<string>().Configure(p=>p.HasMaxLength(100));
        }

       
    }
}