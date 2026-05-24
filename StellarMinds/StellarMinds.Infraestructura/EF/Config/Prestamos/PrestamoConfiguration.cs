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
                   .HasForeignKey(p => p.Telescopio.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Montura)
                   .WithMany()
                   .HasForeignKey(p => p.Montura.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Ocular)
                   .WithMany()
                   .HasForeignKey(p => p.Ocular.Id)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Camara)
                   .WithMany()
                   .HasForeignKey(p => p.Camara.Id)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

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