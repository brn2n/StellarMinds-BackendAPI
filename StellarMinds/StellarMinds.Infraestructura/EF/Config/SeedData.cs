using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO;
using StellarMinds.LogicaNegocio.VO.VOUsuario;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.VO;

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

            if (!_context.ObjetosCelestes.Any())
                CrearObjetosCelestes();

            if (!_context.Prestamos.Any())
                CrearPrestamos();

            if (!_context.ObjetosCelestes.Any())
                CrearObjetosCelestes();
        }

        private void CrearUsuarios()
        {
            _context.Usuarios.AddRange(
                new Administrador(0, new VONombreCompleto("Admin", "Sistema"), new VOTelefono(99111222), new VOUsername("admin"), new VOPassword("Admin123!")),
                new Administrador(0, new VONombreCompleto("Lucia", "Admin"), new VOTelefono(99111223), new VOUsername("admin2"), new VOPassword("Admin123!")),

                new Coordinador(0, new VONombreCompleto("Carlos", "Coordinador"), new VOTelefono(99222333), new VOUsername("coord"), new VOPassword("Coord123!")),
                new Coordinador(0, new VONombreCompleto("Martin", "Coordinador"), new VOTelefono(99222334), new VOUsername("coord2"), new VOPassword("Coord123!")),

                new Socio(0, new VONombreCompleto("Fernando", "Arriondo"), new VOTelefono(99333444), new VOUsername("fer"), new VOPassword("Fer12345!")),
                new Socio(0, new VONombreCompleto("Juan", "Perez"), new VOTelefono(99333445), new VOUsername("juan"), new VOPassword("Socio123!")),
                new Socio(0, new VONombreCompleto("Ana", "Lopez"), new VOTelefono(99333446), new VOUsername("ana"), new VOPassword("Socio123!")),
                new Socio(0, new VONombreCompleto("Sofia", "Gomez"), new VOTelefono(99333447), new VOUsername("sofia"), new VOPassword("Socio123!")),
                new Socio(0, new VONombreCompleto("Diego", "Suarez"), new VOTelefono(99333448), new VOUsername("diego"), new VOPassword("Socio123!")),
                new Socio(0, new VONombreCompleto("Valentina", "Rodriguez"), new VOTelefono(99333449), new VOUsername("vale"), new VOPassword("Socio123!"))
            );

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

        private void CrearPrestamos()
        {
            var socios = _context.Usuarios.OfType<Socio>().ToList();
            var telescopios = _context.Equipos.OfType<Telescopio>().ToList();
            var monturas = _context.Equipos.OfType<Montura>().ToList();
            var camaras = _context.Equipos.OfType<Camara>().ToList();
            var oculares = _context.Equipos.OfType<Ocular>().ToList();

            if (socios.Count < 6 || telescopios.Count < 10 || monturas.Count < 10 || camaras.Count < 10 || oculares.Count < 10)
                throw new Exception("No hay suficientes datos para crear los préstamos del seed.");

            _context.Prestamos.AddRange(
                // Todos tienen FechaFin futura y usan equipos distintos.
                // Así no chocan con la lógica de equipos EN_PRESTAMO.
                new Prestamo(DateTime.Now.AddDays(7), socios[0], monturas[0], oculares[0], telescopios[0], camaras[0], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(8), socios[1], monturas[1], oculares[1], telescopios[1], camaras[1], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(9), socios[2], monturas[2], oculares[2], telescopios[2], camaras[2], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(10), socios[3], monturas[3], oculares[3], telescopios[3], camaras[3], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(11), socios[4], monturas[4], oculares[4], telescopios[4], camaras[4], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(12), socios[5], monturas[5], oculares[5], telescopios[5], camaras[5], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(13), socios[0], monturas[6], oculares[6], telescopios[6], camaras[6], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(14), socios[1], monturas[7], oculares[7], telescopios[7], camaras[7], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(15), socios[2], monturas[8], oculares[8], telescopios[8], camaras[8], Estado.EN_PRESTAMO),
                new Prestamo(DateTime.Now.AddDays(16), socios[3], monturas[9], oculares[9], telescopios[9], camaras[9], Estado.EN_PRESTAMO)
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
    }
}

