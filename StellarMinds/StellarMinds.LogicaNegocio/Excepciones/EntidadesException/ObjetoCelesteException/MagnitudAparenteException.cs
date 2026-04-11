using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.NocheObservacionException;

public class MagnitudAparenteException : LogicaNegocioExcepcion
{
    public MagnitudAparenteException()
    {
    }

    public MagnitudAparenteException(string? message) : base(message)
    {
    }
}