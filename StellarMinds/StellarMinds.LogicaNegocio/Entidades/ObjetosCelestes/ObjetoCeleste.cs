namespace StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes
{
    public class ObjetoCeleste
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public int Magnitud { get; private set; }

        private ObjetoCeleste()
        {

        }

        public ObjetoCeleste(string nombre, string tipo, int magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Magnitud = magnitud;
            Validar();
        }

        private void Validar()
        {
            //HACER VALIDACIONES
        }
    }
}
