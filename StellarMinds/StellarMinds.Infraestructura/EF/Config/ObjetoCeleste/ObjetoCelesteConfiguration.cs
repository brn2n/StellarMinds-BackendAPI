using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.EF.Config.ObjetosCelestes
{
    public class ObjetoCelesteConfiguration : IEntityTypeConfiguration<ObjetoCeleste>
    {
        public void Configure(EntityTypeBuilder<ObjetoCeleste> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nombre)
                   .IsRequired();

            builder.Property(o => o.Tipo)
                   .IsRequired();

            builder.OwnsOne(o => o.Magnitud, magnitud =>
            {
                magnitud.Property(m => m.Valor)
                        .HasColumnName("Magnitud")
                        .IsRequired();
            });
        }
    }
}