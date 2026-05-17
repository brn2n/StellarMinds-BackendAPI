using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record VOTelefono
    {
        public int Value { get; }

        public VOTelefono(int value)
        {
            Value = value;

            Validar();
        }

        private void Validar()
        {
            if (Value < 10000000 || Value > 99999999)
            {
                throw new VOTelefonoInvalidoException();
            }
        }
    }
}
