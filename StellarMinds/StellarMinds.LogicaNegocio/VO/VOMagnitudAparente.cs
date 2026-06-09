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
            string texto = Valor.ToString("F2");

            string patronMagnitud = @"^-?\d+([.,]\d{2})$";

            if (!Regex.IsMatch(texto, patronMagnitud))
            {
                throw new VOMagnitudAparenteInvalidaException(
                    "La magnitud debe ser un numero con exactamente dos decimales."
                );
            }
        }
    }
}