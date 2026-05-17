using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOUsername
    {
        public string Value { get; }

        public VOUsername(string value)
        {
            Value = value;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Length < 3 || Value.Length > 20)
            {
                throw new VOUsernameInvalidoException();
            }
        }
    }
}