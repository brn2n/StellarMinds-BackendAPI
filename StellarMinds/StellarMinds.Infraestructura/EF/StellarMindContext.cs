using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.EF.Config.Equipos;
using StellarMinds.Infraestructura.EF.Config.NocheObservaciones;
using StellarMinds.Infraestructura.EF.Config.ObjetosCelestes;
using StellarMinds.Infraestructura.EF.Config.Prestamos;
using StellarMinds.Infraestructura.EF.Config.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.EF
{
    public class StellarMindContext : DbContext
    {
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        public DbSet<NocheObservacion> NochesObservaciones { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<AuditoriaPrestamo> AuditoriasPrestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StellarMindDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new CamaraConfiguration());
            modelBuilder.ApplyConfiguration(new MonturaConfiguration());
            modelBuilder.ApplyConfiguration(new OcularConfiguration());
            modelBuilder.ApplyConfiguration(new TelescopioConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            modelBuilder.ApplyConfiguration(new NocheObservacionConfiguration());
            modelBuilder.ApplyConfiguration(new UsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new AdministradorConfiguration());
            modelBuilder.ApplyConfiguration(new SocioConfiguration());
            modelBuilder.ApplyConfiguration(new CoordinadorConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetoCelesteConfiguration());
        }
    }
}
