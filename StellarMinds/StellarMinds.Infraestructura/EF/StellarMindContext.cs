using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.EF
{
    public class StellarMindContext : DbContext
    {
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        //public DbSet<NocheObservacion> NochesObservaciones { get; set; }
        //public DbSet<Prestamo> Prestamos { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Equipo> Equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StellarMindDB;Integrated Security=True;");
        }
    }
}
