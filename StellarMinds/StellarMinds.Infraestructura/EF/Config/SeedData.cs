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
            if (!_context.Usuarios.Any())
                CrearUsuarios();

            if (!_context.Equipos.Any())
                CrearEquipos();

            if (!_context.Prestamos.Any())
                CrearPrestamos();
        }

        private void CrearUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Administrador(
                    0,
                    new VONombreCompleto("Admin", "Sistema"),
                    new VOTelefono(99111222),
                    new VOUsername("admin"),
                    new VOPassword("Admin123!")
                ),

                new Coordinador(
                    0,
                    new VONombreCompleto("Carlos", "Coordinador"),
                    new VOTelefono(99222333),
                    new VOUsername("coord"),
                    new VOPassword("Coord123!")
                ),

                new Socio(
                    0,
                    new VONombreCompleto("Fernando", "Arriondo"),
                    new VOTelefono(99333444),
                    new VOUsername("fer"),
                    new VOPassword("Fer12345!")
                ),

                new Socio(
                    0,
                    new VONombreCompleto("Mateo", "Perez"),
                    new VOTelefono(99444555),
                    new VOUsername("mateo"),
                    new VOPassword("Mateo123!")
                ),

                new Socio(
                    0,
                    new VONombreCompleto("Valentina", "Suarez"),
                    new VOTelefono(99555666),
                    new VOUsername("vale"),
                    new VOPassword("Vale12345!")
                ),

                new Socio(
                    0,
                    new VONombreCompleto("Sofia", "Rodriguez"),
                    new VOTelefono(99666777),
                    new VOUsername("sofia"),
                    new VOPassword("Sofia123!")
                )
            };

            _context.Usuarios.AddRange(usuarios);
            _context.SaveChanges();
        }

        private void CrearEquipos()
        {
            var equipos = new List<Equipo>
            {
                new Telescopio(
                    "SkyWatcher",
                    "Explorer 130P",
                    5,
                    130,
                    "f/5",
                    650,
                    8
                ),

                new Telescopio(
                    "Celestron",
                    "AstroMaster 130EQ",
                    4,
                    130,
                    "f/5",
                    650,
                    9
                ),

                new Telescopio(
                    "Meade",
                    "Polaris 114",
                    3,
                    114,
                    "f/8",
                    900,
                    7
                ),

                new Montura(
                    "SkyWatcher",
                    "EQ3",
                    4,
                    TipoMontura.Ecuatorial,
                    10,
                    true
                ),

                new Montura(
                    "Celestron",
                    "CG-4",
                    3,
                    TipoMontura.Ecuatorial,
                    12,
                    false
                ),

                new Montura(
                    "Orion",
                    "Hybrid X",
                    2,
                    TipoMontura.Hibrida,
                    15,
                    true
                ),

                new Camara(
                    "ZWO",
                    "ASI120MC",
                    4,
                    TipoSensorCamara.CMOS,
                    1280,
                    4
                ),

                new Camara(
                    "QHY",
                    "QHY5III",
                    3,
                    TipoSensorCamara.CMOS,
                    1920,
                    3
                ),

                new Ocular(
                    "Baader",
                    "Hyperion 13mm",
                    8,
                    13,
                    68
                ),

                new Ocular(
                    "Celestron",
                    "X-Cel LX 9mm",
                    6,
                    9,
                    60
                ),

                new Ocular(
                    "Explore Scientific",
                    "14mm",
                    5,
                    14,
                    82
                )
            };

            _context.Equipos.AddRange(equipos);
            _context.SaveChanges();
        }

        private void CrearPrestamos()
        {
            var socios = _context.Usuarios.OfType<Socio>().ToList();

            var telescopios = _context.Equipos.OfType<Telescopio>().ToList();
            var monturas = _context.Equipos.OfType<Montura>().ToList();
            var camaras = _context.Equipos.OfType<Camara>().ToList();
            var oculares = _context.Equipos.OfType<Ocular>().ToList();

            var prestamos = new List<Prestamo>
            {
                new Prestamo(
                    DateTime.Now.AddDays(10),
                    socios[0],
                    monturas[0],
                    oculares[0],
                    telescopios[0],
                    camaras[0],
                    Estado.EN_PRESTAMO
                ),

                new Prestamo(
                    DateTime.Now.AddDays(15),
                    socios[1],
                    monturas[1],
                    oculares[1],
                    telescopios[1],
                    camaras[1],
                    Estado.EN_PRESTAMO
                ),

                new Prestamo(
                    DateTime.Now.AddDays(-5),
                    socios[2],
                    monturas[2],
                    oculares[2],
                    telescopios[2],
                    camaras[0],
                    Estado.EN_PRESTAMO
                ),

                new Prestamo(
                    DateTime.Now.AddDays(-20),
                    socios[3],
                    monturas[0],
                    oculares[0],
                    telescopios[0],
                    camaras[1],
                    Estado.DEVUELTO
                )
            };

            _context.Prestamos.AddRange(prestamos);
            _context.SaveChanges();
        }
    }
}