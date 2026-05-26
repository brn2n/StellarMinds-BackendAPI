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
            string patronMagnitud = @"^-?\d+([.,]\d{2})$";

            if (!Regex.IsMatch(Valor.ToString(), patronMagnitud))
            {
                throw new VOMagnitudAparenteInvalidaException("La magnitud debe ser un numero con exactamente dos decimales.");
            }
        }
    }
}