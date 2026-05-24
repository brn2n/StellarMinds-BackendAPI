
using StellarMinds.LogicaNegocio.Excepciones.EntidadesException.EquipoException;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public abstract class Equipo
    {
        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int CantDisponible { get; private set; }

        private Equipo()
        {

        }

        protected Equipo(int id, string marca, string modelo, int cantDisponible)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            CantDisponible = cantDisponible;
            Validar();
        }

        private void Validar()
        {
            if (CantDisponible <= 0)
            {
                throw new EquipoInvalidException("La cantidad disponible del equipo debe ser mayor que cero.");
            }

            if (string.IsNullOrWhiteSpace(Marca))
            {
                throw new EquipoInvalidException("La marca del equipo no puede estar vacía.");
            }

            if (string.IsNullOrWhiteSpace(Modelo))
            {
                throw new EquipoInvalidException("El modelo del equipo no puede estar vacío.");
            }
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
