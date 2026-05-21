using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config.Equipos
{
    public class OcularConfiguration : IEntityTypeConfiguration<Ocular>
    {
        public void Configure(EntityTypeBuilder<Ocular> builder)
        {
            builder.HasBaseType<Equipo>();
        }
    }
}
