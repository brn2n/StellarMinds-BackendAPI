using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class Prestamo
    {
        public int Id { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public Ocular Ocular { get; private set; }
        public Telescopio Telescopio { get; private set; }
        public Camara Camara { get; private set; }
        public Montura Montura { get; private set; }

        public Estado Estado { get; private set; } = Estado.EN_PRESTAMO;

        private Prestamo()
        {

        }

        public Prestamo(DateTime fechaFin, Montura montura, Ocular ocular, Telescopio telescopio, Camara camara, Estado estado)
        {
            FechaFin = fechaFin;
            FechaInicio = DateTime.Now;
            Montura = montura;
            Ocular = ocular;
            Telescopio = telescopio;
            Camara = camara;
            Estado = estado;
            Validar();
        }

        private void Validar()
        {
            if (FechaFin <= FechaInicio)
            {
                throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio.");
            }
            if (Camara == null && Ocular == null)
            {
                throw new ArgumentException("Debe seleccionarse al menos una camara o un ocular.");
            }
            if (Camara != null)
            {
                if (Montura.TipoMontura != TipoMontura.Ecuatorial && Montura.TipoMontura != TipoMontura.Hibrida)
                {
                    throw new ArgumentException("Para prestar una cámara, la montura debe ser ecuatorial o híbrida.");
                }
            }
        }
    }
}
