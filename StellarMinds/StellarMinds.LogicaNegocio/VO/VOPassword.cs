using StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOPassword : VOString
    {
        public string Value { get; private set; }

        public VOPassword(string value) : base(value)
        {
            Value = value;
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            throw new PasswordInvalidException(errorMsg);
        }

        //corregir esto y poner la validacion correcta de password
        protected override bool IsAllowdValue(string value, out string errorMsg)
        {
            if (!base.IsAllowdValue(value, out errorMsg))
            {
                return false;
            }
            if (value.Length > 10)
            {
                errorMsg = $"El nombre '{value}' debe tener menos de 10 caracteres.";
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
    }
}
