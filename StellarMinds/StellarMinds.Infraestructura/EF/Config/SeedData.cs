using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.Infraestructura.EF
{
    public class SeedData
    {
        private readonly StellarMindContext _context;

        public SeedData(StellarMindContext context)
        {
            _context = context;
        }

        public void Run()
        {
            CrearUsuarios();

            if (!_context.Equipos.Any())
                CrearEquipos();

            if (!_context.Prestamos.Any())
                CrearPrestamos();
        }

        private void CrearUsuarios()
        {
            if (!_context.Usuarios.Any(u => u.Username.Value == "admin"))
            {
                _context.Usuarios.Add(new Administrador(
                    0,
                    new VONombreCompleto("Admin", "Sistema"),
                    new VOTelefono(99111222),
                    new VOUsername("admin"),
                    new VOPassword("Admin123!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "coord"))
            {
                _context.Usuarios.Add(new Coordinador(
                    0,
                    new VONombreCompleto("Carlos", "Coordinador"),
                    new VOTelefono(99222333),
                    new VOUsername("coord"),
                    new VOPassword("Coord123!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "lucia.coord"))
            {
                _context.Usuarios.Add(new Coordinador(
                    0,
                    new VONombreCompleto("Lucia", "Rodriguez"),
                    new VOTelefono(99222444),
                    new VOUsername("lucia.coord"),
                    new VOPassword("Coord123!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "fer"))
            {
                _context.Usuarios.Add(new Socio(
                    0,
                    new VONombreCompleto("Fernando", "Arriondo"),
                    new VOTelefono(99333444),
                    new VOUsername("fer"),
                    new VOPassword("Fer12345!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "mateo"))
            {
                _context.Usuarios.Add(new Socio(
                    0,
                    new VONombreCompleto("Mateo", "Pereira"),
                    new VOTelefono(99444555),
                    new VOUsername("mateo"),
                    new VOPassword("Mateo123!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "vale"))
            {
                _context.Usuarios.Add(new Socio(
                    0,
                    new VONombreCompleto("Valentina", "Gomez"),
                    new VOTelefono(99555666),
                    new VOUsername("vale"),
                    new VOPassword("Vale123!")
                ));
            }

            if (!_context.Usuarios.Any(u => u.Username.Value == "sofia"))
            {
                _context.Usuarios.Add(new Socio(
                    0,
                    new VONombreCompleto("Sofia", "Martinez"),
                    new VOTelefono(99666777),
                    new VOUsername("sofia"),
                    new VOPassword("Sofia123!")
                ));
            }

            _context.SaveChanges();
        }

        private void CrearEquipos()
        {
            _context.Equipos.AddRange(
                new Telescopio(0, "ACME", "Valenton 130EQ", 3, 130, "f/5", 650, 12),
                new Telescopio(0, "Celestron", "AstroMaster 130EQ", 4, 130, "f/5", 650, 11.5),
                new Telescopio(0, "SkyWatcher", "Dobson 200P", 2, 200, "f/6", 1200, 20),
                new Telescopio(0, "Meade", "Infinity 102", 1, 102, "f/5.9", 600, 6.2),

                new Montura(0, "ACME", "Guilleton", 2, TipoMontura.Ecuatorial, 9.5, true),
                new Montura(0, "SkyWatcher", "EQ3", 3, TipoMontura.Ecuatorial, 15, true),
                new Montura(0, "Celestron", "Altazimutal AZ", 2, TipoMontura.AltAzimutal, 8, false),
                new Montura(0, "Meade", "LX85", 1, TipoMontura.Ecuatorial, 12, true),

                new Camara(0, "ACME", "Colon", 2, TipoSensorCamara.CMOS, 1280, 3),
                new Camara(0, "ZWO", "ASI120MC", 3, TipoSensorCamara.CMOS, 1280, 3),
                new Camara(0, "Canon", "EOS Rebel T7", 1, TipoSensorCamara.CMOS, 6000, 4),
                new Camara(0, "Atik", "Infinity CCD", 1, TipoSensorCamara.CCD, 1392, 6),

                new Ocular(0, "Baader", "Hyperion", 5, 13, 68),
                new Ocular(0, "Celestron", "Plossl 25mm", 5, 25, 52),
                new Ocular(0, "SkyWatcher", "Super 10mm", 4, 10, 50),
                new Ocular(0, "Explore Scientific", "82° 14mm", 2, 14, 82)
            );

            _context.SaveChanges();
        }

        private void CrearPrestamos()
        {
            var socio1 = _context.Usuarios.OfType<Socio>().First(s => s.Username.Value == "fer");
            var socio2 = _context.Usuarios.OfType<Socio>().First(s => s.Username.Value == "mateo");
            var socio3 = _context.Usuarios.OfType<Socio>().First(s => s.Username.Value == "vale");
            var socio4 = _context.Usuarios.OfType<Socio>().First(s => s.Username.Value == "sofia");

            var telescopios = _context.Equipos.OfType<Telescopio>().ToList();
            var camaras = _context.Equipos.OfType<Camara>().ToList();
            var oculares = _context.Equipos.OfType<Ocular>().ToList();

            var monturasValidasParaCamara = _context.Equipos
                .OfType<Montura>()
                .Where(m => m.TipoMontura == TipoMontura.Ecuatorial || m.TipoMontura == TipoMontura.Hibrida)
                .ToList();

            var prestamos = new List<Prestamo>
            {
                new Prestamo(DateTime.Now.AddDays(7), socio1, monturasValidasParaCamara[0], oculares[0], telescopios[0], camaras[0], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(15), socio2, monturasValidasParaCamara[1], oculares[1], telescopios[0], camaras[1], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(10), socio3, monturasValidasParaCamara[2], oculares[2], telescopios[1], camaras[2], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(20), socio4, monturasValidasParaCamara[0], oculares[3], telescopios[2], camaras[3], Estado.EN_PRESTAMO),

                new Prestamo(DateTime.Now.AddDays(30), socio1, monturasValidasParaCamara[1], oculares[1], telescopios[1], camaras[0], Estado.DEVUELTO),
                new Prestamo(DateTime.Now.AddDays(25), socio2, monturasValidasParaCamara[2], oculares[2], telescopios[2], camaras[1], Estado.DEVUELTO),
                new Prestamo(DateTime.Now.AddDays(18), socio3, monturasValidasParaCamara[0], oculares[0], telescopios[0], camaras[2], Estado.DEVUELTO),
                new Prestamo(DateTime.Now.AddDays(12), socio4, monturasValidasParaCamara[1], oculares[3], telescopios[0], camaras[3], Estado.DEVUELTO)
            };

            _context.Prestamos.AddRange(prestamos);
            _context.SaveChanges();
        }
    }
}