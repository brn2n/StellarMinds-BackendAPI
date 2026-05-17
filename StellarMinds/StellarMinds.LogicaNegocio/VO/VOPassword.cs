using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOPassword
    {
        public string Value { get; }

        public VOPassword(string value)
        {
            Value = value;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Length < 6)
            {
                throw new VOPasswordInvalidoException();
            }
        }
    }
}
