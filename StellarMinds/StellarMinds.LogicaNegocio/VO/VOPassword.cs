using StellarMinds.LogicaNegocio.Excepciones;
using System.Text.RegularExpressions;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOPassword
    {
        public string Value { get; }

        private VOPassword()
        {
        }

        public VOPassword(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (Value == null)
            {
                throw new VOPasswordInvalidoException();
            }

            string patronRegEx = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*(),.?"":{}|<>]).{8,}$";

            if (!Regex.IsMatch(Value, patronRegEx))
            {
                throw new VOPasswordInvalidoException();
            }
        }
    }
}
