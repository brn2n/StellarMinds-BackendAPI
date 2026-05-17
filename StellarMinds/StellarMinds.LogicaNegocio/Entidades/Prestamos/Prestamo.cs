using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class Prestamo
    {
        public int Id { get; private set; }
        public DateTime FechaInicio { get; private set; } = DateTime.Now;
        public DateTime VOFechaFin { get; private set; }
        public List<Equipo> Equipos { get; private set; }
        public Ocular Ocular { get; private set; }
        public Telescopio Telescopio { get; private set; }
        public Camara Camara { get; private set; }
        public Montura Montura { get; private set; }

        public Estado Estado { get; private set; } = Estado.EN_PRESTAMO;

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
            Validar();
        }

        private void Validar()
        {
            //HACER VALIDACIONES
        }
    }
}
