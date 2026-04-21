namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record VONombreCompleto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public VONombreCompleto(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            //Validar();
        }

        private void Validar()
        {
            throw new NotImplementedException(); //AGREGAR VALIDACION
        }
    }
}
