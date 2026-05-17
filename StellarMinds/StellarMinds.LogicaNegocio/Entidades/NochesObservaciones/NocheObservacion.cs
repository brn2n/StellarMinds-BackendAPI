using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaNegocio.Entidades.NochesObservaciones
{
    public class NocheObservacion
    {
        public int Id { get; private set; }
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
            //HACER VALIDACIONES
        }
    }
}
