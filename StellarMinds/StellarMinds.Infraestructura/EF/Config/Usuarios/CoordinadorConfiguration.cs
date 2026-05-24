using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.EF.Config.Usuarios
{
    public class CoordinadorConfiguration : IEntityTypeConfiguration<Coordinador>
    {
        public void Configure(EntityTypeBuilder<Coordinador> builder)
        {
            builder.HasBaseType<Usuario>();
        }
    }
}
