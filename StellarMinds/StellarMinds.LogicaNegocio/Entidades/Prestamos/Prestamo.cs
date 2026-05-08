using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class Prestamo
    {
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime VOFechaFin { get; set; }
        public List<Equipo> Equipos { get; set; }
        public Ocular Ocular { get; set; }
        public Telescopio Telescopio { get; set; }
        public Camara Camara { get; set; }
        public Montura Montura { get; set; }

        public Estado Estado { get; set; } = Estado.EN_PRESTAMO;

        private Prestamo()
        {

        }

        public Prestamo(DateTime voFechaFin, Montura montura, Ocular ocular, Telescopio telescopio, Camara camara, Estado estado)
        {
            VOFechaFin = voFechaFin;
            Montura = montura;
            Ocular = ocular;
            Telescopio = telescopio;
            Camara = camara;
            Estado = estado;
        }
    }
}
