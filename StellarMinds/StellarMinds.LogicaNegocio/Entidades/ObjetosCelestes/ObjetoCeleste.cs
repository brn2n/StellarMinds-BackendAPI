using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.VO;
using System.Text.RegularExpressions;

namespace StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes
{
    public class ObjetoCeleste
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public VOMagnitudAparente Magnitud { get; private set; }

        private ObjetoCeleste()
        {

        }

        public ObjetoCeleste(string nombre, string tipo, VOMagnitudAparente magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Magnitud = magnitud;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new ObjetoCelesteInvalidoException("El nombre del objeto celeste no puede estar en blanco.");
            }

            if (string.IsNullOrWhiteSpace(Tipo))
            {
                throw new ObjetoCelesteInvalidoException("El tipo del objeto celeste no puede estar en blanco.");
            }

            if (Magnitud == null)
            {
                throw new ObjetoCelesteInvalidoException("La magnitud del objeto celeste no puede ser nula.");
            }

            string patronMagnitud = @"^-?\d+([.,]\d{2})$";

            if (!Regex.IsMatch(Magnitud.ToString(), patronMagnitud))
            {
                throw new ObjetoCelesteInvalidoException("La magnitud debe ser un numero con exactamente dos decimales.");
            }
        }
    }
}