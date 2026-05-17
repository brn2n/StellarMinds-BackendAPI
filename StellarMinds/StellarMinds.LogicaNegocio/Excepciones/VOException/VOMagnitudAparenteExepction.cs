
namespace StellarMinds.LogicaNegocio.Excepciones;

public class VOMagnitudAparenteInvalidaException : Exception
{
    public VOMagnitudAparenteInvalidaException()
        : base("La magnitud aparente ingresada no es válida.")
    {
    }

    public VOMagnitudAparenteInvalidaException(string mensaje)
        : base(mensaje)
    {
    }
}