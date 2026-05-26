//using StellarMinds.LogicaNegocio.Entidades.Equipos;
//using StellarMinds.LogicaNegocio.Entidades.Prestamos;
//using StellarMinds.LogicaNegocio.Entidades.Usuarios;
//using StellarMinds.LogicaNegocio.VO.VOUsuario;

//namespace StellarMinds.Infraestructura.EF
//{
//    public class SeedData
//    {
//        private readonly StellarMindContext _context;

//        public SeedData(StellarMindContext context)
//        {
//            _context = context;
//        }

//        public void Run()
//        {
//            if (!_context.Usuarios.Any())
//                CrearUsuarios();

//            if (!_context.Equipos.Any())
//                CrearEquipos();

//            if (!_context.Prestamos.Any())
//                CrearPrestamos();
//        }

//        private void CrearUsuarios()
//        {
//            var admin = new Administrador(
//                0,
//                new VONombreCompleto("Admin", "Sistema"),
//                new VOTelefono(99111222),
//                new VOUsername("admin"),
//                new VOPassword("Admin123!")
//            );

//            var coordinador = new Coordinador(
//                0,
//                new VONombreCompleto("Carlos", "Coordinador"),
//                new VOTelefono(99222333),
//                new VOUsername("coord"),
//                new VOPassword("Coord123!")
//            );

//            var socio = new Socio(
//                0,
//                new VONombreCompleto("Fernando", "Arriondo"),
//                new VOTelefono(99333444),
//                new VOUsername("fer"),
//                new VOPassword("Fer12345!")
//            );

//            _context.Usuarios.Add(admin);
//            _context.Usuarios.Add(coordinador);
//            _context.Usuarios.Add(socio);

//            _context.SaveChanges();
//        }

//        private void CrearEquipos()
//        {
//            var telescopio = new Telescopio(
//                0,
//                "ACME",
//                "Valenton 130EQ",
//                3,
//                130,
//                "f/5",
//                650,
//                12
//            );

//            var montura = new Montura(
//                0,
//                "ACME",
//                "Guilleton",
//                2,
//                TipoMontura.Ecuatorial,
//                9.5,
//                true
//            );

//            var camara = new Camara(
//                0,
//                "ACME",
//                "Colon",
//                2,
//                TipoSensorCamara.CMOS,
//                1280,
//                3
//            );

//            var ocular = new Ocular(
//                0,
//                "Baader",
//                "Hyperion",
//                5,
//                13,
//                68
//            );

//            _context.Equipos.Add(telescopio);
//            _context.Equipos.Add(montura);
//            _context.Equipos.Add(camara);
//            _context.Equipos.Add(ocular);

//            _context.SaveChanges();
//        }

//        private void CrearPrestamos()
//        {
//            var telescopio = _context.Equipos.OfType<Telescopio>().First();
//            var montura = _context.Equipos.OfType<Montura>().First();
//            var camara = _context.Equipos.OfType<Camara>().First();
//            var ocular = _context.Equipos.OfType<Ocular>().First();

//            var prestamo = new Prestamo(
//                DateTime.Now.AddDays(7),
//                montura,
//                ocular,
//                telescopio,
//                camara,
//                Estado.EN_PRESTAMO
//            );

//            _context.Prestamos.Add(prestamo);
//            _context.SaveChanges();
//        }
//    }
//}