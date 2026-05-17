using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.Entidades.NochesObservaciones
{
    public class NocheObservacion
    {
        public DateTime FechaObservacion { get; private set; }
        public Prestamo Prestamo { get; private set; }
        public ObjetoCeleste ObjetoCeleste { get; private set; }

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
            if (FechaObservacion == default)
            {
                throw new NocheObservacionInvalidaException();
            }

            if (Prestamo == null)
            {
                throw new NocheObservacionInvalidaException();
            }

            if (ObjetoCeleste == null)
            {
                throw new NocheObservacionInvalidaException();
            }
        }
    }
}
