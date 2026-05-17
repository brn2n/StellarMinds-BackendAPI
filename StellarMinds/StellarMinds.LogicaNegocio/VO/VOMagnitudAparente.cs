using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record class VOMagnitudAparente
    {
        public double Valor { get; }

        public VOMagnitudAparente(double valor)
        {
            Valor = valor;

            Validar();
        }

        private void Validar()
        {
            if (Valor < -30 || Valor > 30)
            {
                throw new VOMagnitudAparenteInvalidaException();
            }
        }
    }
}