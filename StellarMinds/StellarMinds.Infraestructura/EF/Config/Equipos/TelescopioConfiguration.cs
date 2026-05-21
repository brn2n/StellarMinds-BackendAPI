using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config.Equipos
{
    public class TelescopioConfiguration : IEntityTypeConfiguration<Telescopio>
    {
        public void Configure(EntityTypeBuilder<Telescopio> builder)
        {
            builder.HasBaseType<Equipo>();
        }
    }
}
