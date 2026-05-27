using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.EF.Config.Prestamos
{
    public class AuditoriaPrestamoConfiguration : IEntityTypeConfiguration<AuditoriaPrestamo>
    {
        public void Configure(EntityTypeBuilder<AuditoriaPrestamo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Accion)
                   .IsRequired();

            builder.Property(a => a.Fecha)
                   .IsRequired();

            builder.HasOne(a => a.Prestamo)
                   .WithMany()
                   .HasForeignKey(a => a.PrestamoId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}