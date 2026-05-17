using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VONombreObjetoCeleste
    {
        public string Valor { get; }

        public VONombreObjetoCeleste(string valor)
        {
            Valor = valor;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Valor) || Valor.Length > 100)
            {
                throw new VONombreObjetoCelesteInvalidoException();
            }
        }
    }
}