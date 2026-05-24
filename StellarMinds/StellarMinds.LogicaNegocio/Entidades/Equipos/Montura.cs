namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Montura : Equipo
    {
        public TipoMontura TipoMontura { get; private set; }
        public double CargaUtilSoportada { get; private set; }
        public bool Computarizada { get; private set; }

        protected Montura()
        {
        }
        public Montura(int id, string marca, string modelo, int cantDisponible, TipoMontura tipoMontura, double cargaUtilSoportada, bool computarizada) : base(id, marca, modelo, cantDisponible)
        {
            TipoMontura = tipoMontura;
            CargaUtilSoportada = cargaUtilSoportada;
            Computarizada = computarizada;
        }

        public void Update(Montura obj)
        {
            base.Update(obj);
            TipoMontura = obj.TipoMontura;
            CargaUtilSoportada = obj.CargaUtilSoportada;
            Computarizada = obj.Computarizada;
        }
    }
}
