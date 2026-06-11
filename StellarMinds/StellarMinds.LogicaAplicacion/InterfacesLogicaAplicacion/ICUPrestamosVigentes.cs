namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUPrestamosVigentes<T>
    {
        IEnumerable<T> Execute(int socioId);
    }
}
