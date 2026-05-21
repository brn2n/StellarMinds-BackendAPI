using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config.Equipos
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasDiscriminator<string>("TipoEquipo")
                .HasValue<Camara>("Camara")
                .HasValue<Montura>("Montura")
                .HasValue<Ocular>("Ocular")
                .HasValue<Telescopio>("Telescopio");
        }
    }
}
