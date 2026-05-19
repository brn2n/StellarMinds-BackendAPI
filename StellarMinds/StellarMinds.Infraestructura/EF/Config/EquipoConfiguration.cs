using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Equipo> builder)
        {
            builder.ToTable("Equipos");
            builder.HasKey(a => a.Id);

        }
    }
}
