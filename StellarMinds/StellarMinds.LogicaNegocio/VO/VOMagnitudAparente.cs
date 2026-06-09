using StellarMinds.LogicaNegocio.Excepciones;
using System.Text.RegularExpressions;

namespace StellarMinds.LogicaNegocio.VO
{
    public record class VOMagnitudAparente
    {
        public double Valor { get; private set; }

        private VOMagnitudAparente()
        {
        }
        public VOMagnitudAparente(double valor)
        {
            Valor = valor;

            Validar();
        }

        private void Validar()
        {
            // Forzamos que se convierta a string usando punto decimal y siempre con dos decimales ("F2")
            // Ejemplo: -1.4 -> "-1.40"
            string valorTexto = Valor.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            // La regex ahora solo se preocupa por validar sobre un formato controlado y seguro
            string patronMagnitud = @"^-?\d+(\.\d{2})$";

            if (!Regex.IsMatch(valorTexto, patronMagnitud))
            {
                throw new VOMagnitudAparenteInvalidaException("La magnitud debe tener un formato numérico válido.");
            }
        }
    }
}