namespace StellarMinds.LogicaNegocio.VO.VOUsuario;

public abstract record VOString
{
    public string Value { get; private set; }

    public VOString(string value)
    {
        Value = value;
        if (!IsAllowdValue(value, out string errorMsg))
        {
            throw CreateInvalidValueException(value, errorMsg);
        }
    }
    protected abstract Exception CreateInvalidValueException(string value, string errorMsg);
    protected virtual bool IsAllowdValue(string value, out string errorMsg)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            errorMsg = "El valor no puede estar vacío.";
            return false;
        }
        errorMsg = string.Empty;
        return true;
    }
}