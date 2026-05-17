using StellarMinds.LogicaNegocio.Excepciones;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record VONombreCompleto
    {
        public string Nombre { get; }
        public string Apellido { get; }

        public VONombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Apellido) ||
                Nombre.Length > 50 ||
                Apellido.Length > 50)
            {
                throw new VONombreCompletoInvalidoException();
            }
        }
    }
}