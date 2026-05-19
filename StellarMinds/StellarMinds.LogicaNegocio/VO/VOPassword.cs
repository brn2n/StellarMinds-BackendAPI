namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOPassword
    {
        public string Value { get; }

        public VOPassword(string value)
        {
            Value = value;
            //Validar();
        }

        private void Validar()
        {
            //    throw new NotImplementedException(); // Aquí puedes implementar la lógica de validación para la contraseña, como verificar su longitud, complejidad, etc.
        }
    }
}
