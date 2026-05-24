using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.EF.Config.Prestamos
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Telescopio)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Montura)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Ocular)
                   .WithMany()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Camara)
                   .WithMany()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Estado)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(p => p.FechaInicio)
                   .IsRequired();

            builder.Property(p => p.FechaFin)
                   .IsRequired();
        }
    }
}