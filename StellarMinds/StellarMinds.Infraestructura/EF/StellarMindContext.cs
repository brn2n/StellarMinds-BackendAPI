using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.EF
{
    public class StellarMindContext : DbContext
    {
        public DbSet<ObjetoCeleste> ObjetoCeleste { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=StellarMinds;Integrated Security=true;");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
