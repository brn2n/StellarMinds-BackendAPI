using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaNegocio.Entidades.NochesObservaciones
{
    public class NocheObservacion
    {
        public DateTime FechaObservacion { get; set; }
        public Prestamo Prestamo { get; set; }
        public ObjetoCeleste ObjetoCeleste { get; set; }

        private NocheObservacion()
        {

        }

        public NocheObservacion(DateTime fechaObservacion, Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            FechaObservacion = fechaObservacion;
            Prestamo = prestamo;
            ObjetoCeleste = objetoCeleste;
        }
    }
}
