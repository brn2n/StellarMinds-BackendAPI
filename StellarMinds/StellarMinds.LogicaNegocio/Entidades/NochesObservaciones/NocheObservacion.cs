using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.Entidades.NochesObservaciones
{
    public class NocheObservacion
    {
        public int Id { get; private set; }
        public DateTime FechaObservacion { get; private set; }
        public Prestamo Prestamo { get; private set; }
        public int PrestamoId { get; private set; }

        public ObjetoCeleste ObjetoCeleste { get; private set; }

        public int ObjetoCelesteId { get; private set; }

        private NocheObservacion()
        {

        }

        public NocheObservacion(DateTime fechaObservacion, Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            FechaObservacion = fechaObservacion;
            Prestamo = prestamo;
            ObjetoCeleste = objetoCeleste;

            Validar();
        }

        private void Validar()
        {
            if (FechaObservacion < DateTime.Now)
            {
                throw new NocheObservacionInvalidaException("La fecha de observación no puede ser en el pasado.");
            }

            if (Prestamo == null)
            {
                throw new NocheObservacionInvalidaException("El préstamo no puede ser nulo.");
            }

            if (ObjetoCeleste == null)
            {
                throw new NocheObservacionInvalidaException("El objeto celeste no puede ser nulo.");
            }
        }
    }
}
