using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SiteAreaAdministrativa.Models
{
    public class DataContext :DbContext
    {
        public DataContext():base("ConnectionString")
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Usuario>().ToTable("T_USUARIO");
            modelBuilder.Entity<Usuario>().HasKey(t => t.id);
            modelBuilder.Entity<Usuario>().Property(t => t.nome).IsRequired().HasMaxLength(50).HasColumnName("usu_nome").HasColumnType("VARCHAR");
            modelBuilder.Entity<Usuario>().Property(t => t.usuario).IsRequired().HasMaxLength(50).HasColumnName("usu_usuario").HasColumnType("VARCHAR");
            modelBuilder.Entity<Usuario>().Property(t => t.password).IsRequired().HasMaxLength(50).HasColumnName("usu_password").HasColumnType("VARCHAR");
        }
    }
}