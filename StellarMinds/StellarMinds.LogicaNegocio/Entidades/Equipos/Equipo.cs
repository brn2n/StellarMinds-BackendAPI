
namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public abstract class Equipo
    {
        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int CantDisponible { get; private set; }

        protected Equipo()
        {

        }

        protected Equipo(int id, string marca, string modelo, int cantDisponible)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            CantDisponible = cantDisponible;
        }

        public void Update(Equipo obj)
        {
            Id = obj.Id;
            Marca = obj.Marca;
            Modelo = obj.Modelo;
            CantDisponible = obj.CantDisponible;
        }
    }
}
