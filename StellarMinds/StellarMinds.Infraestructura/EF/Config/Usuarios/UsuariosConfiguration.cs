using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.EF.Config.Usuarios
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasDiscriminator<string>("TipoUsuario")
                    .HasValue<Administrador>("Administrador")
                    .HasValue<Socio>("Socio")
                    .HasValue<Coordinador>("Coordinador");

            builder.OwnsOne(a => a.NombreCompleto, VONombreCompleto =>
            {
                VONombreCompleto.Property(v => v.Nombre);
                VONombreCompleto.Property(v => v.Apellido);
            });

            builder.OwnsOne(a => a.Telefono, VOTelefono =>
            {
                VOTelefono.Property(v => v.Value);
            });

            builder.OwnsOne(a => a.Username, VOUsername =>
            {
                VOUsername.Property(v => v.Value);
            });

            builder.OwnsOne(a => a.VOPassword, VOPassword =>
            {
                VOPassword.Property(v => v.Value);
            });
        }
    }
}
