using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config.Equipos
{
    public class MonturaConfiguration : IEntityTypeConfiguration<Montura>
    {
        public void Configure(EntityTypeBuilder<Montura> builder)
        {
            builder.HasBaseType<Equipo>();

            builder.Property(t => t.TipoMontura)
            .HasConversion<string>();
        }
    }
}
