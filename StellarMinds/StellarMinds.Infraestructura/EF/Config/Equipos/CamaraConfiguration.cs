using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF.Config.Equipos
{
    public class CamaraConfiguration : IEntityTypeConfiguration<Camara>
    {
        public void Configure(EntityTypeBuilder<Camara> builder)
        {
            builder.HasBaseType<Equipo>();

            builder.Property(t => t.TipoSensorCamara)
            .HasConversion<string>();
        }
    }
}
