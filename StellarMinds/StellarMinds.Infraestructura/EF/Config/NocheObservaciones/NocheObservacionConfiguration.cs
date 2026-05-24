using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.Infraestructura.EF.Config.NocheObservaciones
{
    public class NocheObservacionConfiguration : IEntityTypeConfiguration<NocheObservacion>
    {
        public void Configure(EntityTypeBuilder<NocheObservacion> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Prestamo)
                   .WithMany()
                   .HasForeignKey(p => p.Prestamo.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ObjetoCeleste)
                   .WithMany()
                   .HasForeignKey(p => p.ObjetoCeleste.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
