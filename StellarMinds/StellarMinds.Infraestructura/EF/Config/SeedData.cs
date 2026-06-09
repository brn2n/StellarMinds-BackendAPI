using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO;
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

            if (!_context.ObjetosCelestes.Any())
                CrearObjetosCelestes();

            if (!_context.NochesObservaciones.Any())
                CrearNochesObservaciones();
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
            _context.Equipos.AddRange(
                // 10 telescopios
                new Telescopio("SkyWatcher", "Explorer 130EQ", 5, 130, "f/5", 650, 12),
                new Telescopio("Celestron", "AstroMaster 114EQ", 4, 114, "f/8.8", 1000, 9),
                new Telescopio("Orion", "SpaceProbe 130ST", 4, 130, "f/5", 650, 11),
                new Telescopio("Meade", "Polaris 127", 3, 127, "f/7.9", 1000, 10),
                new Telescopio("Bresser", "Messier AR-102", 3, 102, "f/5.9", 600, 6),
                new Telescopio("Explore Scientific", "FirstLight 80", 3, 80, "f/8", 640, 5),
                new Telescopio("SkyWatcher", "Heritage 150P", 3, 150, "f/5", 750, 7),
                new Telescopio("Celestron", "NexStar 6SE", 2, 150, "f/10", 1500, 14),
                new Telescopio("Orion", "StarBlast 102", 3, 102, "f/6.5", 660, 6),
                new Telescopio("Meade", "Infinity 90", 3, 90, "f/6.7", 600, 5),

                // 10 monturas. Todas son Ecuatorial o Hibrida para que puedan usarse con Camara.
                new Montura("SkyWatcher", "EQ3", 5, TipoMontura.Ecuatorial, 9.5, true),
                new Montura("Celestron", "CG-4", 4, TipoMontura.Ecuatorial, 8.0, false),
                new Montura("Orion", "Sirius EQ-G", 3, TipoMontura.Ecuatorial, 13.5, true),
                new Montura("Meade", "LX85 Hybrid", 3, TipoMontura.Hibrida, 12.0, true),
                new Montura("Bresser", "EXOS-2", 3, TipoMontura.Ecuatorial, 13.0, true),
                new Montura("iOptron", "CEM26", 2, TipoMontura.Ecuatorial, 12.0, true),
                new Montura("SkyWatcher", "AZ-EQ5", 2, TipoMontura.Hibrida, 15.0, true),
                new Montura("Celestron", "Advanced VX", 2, TipoMontura.Ecuatorial, 14.0, true),
                new Montura("Orion", "SkyView Pro", 3, TipoMontura.Ecuatorial, 9.0, false),
                new Montura("Meade", "LX70", 2, TipoMontura.Ecuatorial, 9.0, false),

                // 10 camaras
                new Camara("ZWO", "ASI120MC", 5, TipoSensorCamara.CMOS, 1280, 3),
                new Camara("Canon", "EOS Rebel T7", 4, TipoSensorCamara.CMOS, 2400, 4),
                new Camara("Nikon", "D3500", 4, TipoSensorCamara.CMOS, 2400, 4),
                new Camara("QHY", "QHY5III462C", 3, TipoSensorCamara.CMOS, 1920, 2),
                new Camara("ZWO", "ASI224MC", 3, TipoSensorCamara.CMOS, 1304, 3),
                new Camara("QHY", "QHY183C", 2, TipoSensorCamara.CMOS, 5544, 2),
                new Camara("Atik", "414EX", 2, TipoSensorCamara.CCD, 1392, 6),
                new Camara("SBIG", "STF-8300", 1, TipoSensorCamara.CCD, 3326, 5),
                new Camara("Player One", "Neptune-C II", 2, TipoSensorCamara.CMOS, 2712, 2),
                new Camara("Altair", "Hypercam 183C", 2, TipoSensorCamara.CMOS, 5440, 2),

                // 10 oculares
                new Ocular("Baader", "Hyperion 13mm", 5, 13, 68),
                new Ocular("Celestron", "X-Cel LX 25mm", 5, 25, 60),
                new Ocular("SkyWatcher", "Super 10mm", 5, 10, 52),
                new Ocular("Orion", "Sirius Plossl 32mm", 4, 32, 52),
                new Ocular("Explore Scientific", "82 11mm", 3, 11, 82),
                new Ocular("Tele Vue", "Nagler 7mm", 2, 7, 82),
                new Ocular("Meade", "Series 4000 26mm", 4, 26, 52),
                new Ocular("Bresser", "Plossl 15mm", 4, 15, 50),
                new Ocular("Vixen", "NPL 20mm", 3, 20, 50),
                new Ocular("Omegon", "Cronus 5mm", 3, 5, 60),

                //Para AltaPrestamo
                new Ocular("Omegon", "Equipo4", 3, 5, 60),
                new Camara("Altair", "Equipo3", 2, TipoSensorCamara.CMOS, 5440, 2),
                new Montura("Meade", "Equipo2", 2, TipoMontura.Ecuatorial, 9.0, false),
                new Telescopio("Meade", "Equipo1", 3, 90, "f/6.7", 600, 5)
            );
            _context.SaveChanges();
        }

        private void CrearObjetosCelestes()
        {
            _context.ObjetosCelestes.AddRange(
                new ObjetoCeleste("Luna", "Planeta", new VOMagnitudAparente(-12.74)),
                new ObjetoCeleste("Júpiter", "Planeta", new VOMagnitudAparente(-2.20)),
                new ObjetoCeleste("Galaxia M42", "Galaxia", new VOMagnitudAparente(4.00)),
                new ObjetoCeleste("Polaris", "Estrella", new VOMagnitudAparente(1.97)),
                new ObjetoCeleste("Sirio", "Estrella", new VOMagnitudAparente(-1.46)),
                new ObjetoCeleste("Andrómeda", "Galaxia", new VOMagnitudAparente(3.44)),
                new ObjetoCeleste("Nebulosa del Cangrejo", "Nebulosa", new VOMagnitudAparente(8.40)),
                new ObjetoCeleste("Marte", "Planeta", new VOMagnitudAparente(0.71)),
                new ObjetoCeleste("Nebulosa del Anillo", "Nebulosa", new VOMagnitudAparente(8.80)),
                new ObjetoCeleste("Betelgeuse", "Estrella", new VOMagnitudAparente(0.42))
            );

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

        private void CrearNochesObservaciones()
        {
            var prestamos = _context.Prestamos.ToList();
            var objetosCelestes = _context.ObjetosCelestes.ToList();

            if (prestamos.Count < 10 || objetosCelestes.Count < 10)
            {
                throw new Exception("No hay suficientes préstamos o objetos celestes creados para generar las noches de observación.");
            }
            _context.NochesObservaciones.AddRange(
                new NocheObservacion(DateTime.Now.AddDays(1), prestamos[0], objetosCelestes[0]),
                new NocheObservacion(DateTime.Now.AddDays(2), prestamos[1], objetosCelestes[1]),
                new NocheObservacion(DateTime.Now.AddDays(3), prestamos[2], objetosCelestes[2]),
                new NocheObservacion(DateTime.Now.AddDays(4), prestamos[3], objetosCelestes[3]),
                new NocheObservacion(DateTime.Now.AddDays(5), prestamos[4], objetosCelestes[4]),
                new NocheObservacion(DateTime.Now.AddDays(6), prestamos[5], objetosCelestes[5]),
                new NocheObservacion(DateTime.Now.AddDays(7), prestamos[6], objetosCelestes[6]),
                new NocheObservacion(DateTime.Now.AddDays(8), prestamos[7], objetosCelestes[7]),
                new NocheObservacion(DateTime.Now.AddDays(9), prestamos[8], objetosCelestes[8]),
                new NocheObservacion(DateTime.Now.AddDays(10), prestamos[9], objetosCelestes[9])
            );
            _context.SaveChanges();
        }
    }
}