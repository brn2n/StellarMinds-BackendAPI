namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Camara : Equipo
    {
        public TipoSensorCamara TipoSensorCamara { get; private set; }
        public int Resolucion { get; private set; }
        public int TamanioPixel { get; private set; }

        private Camara()
        {

        }
        public Camara(int id, string marca, string modelo, int cantDisponible, TipoSensorCamara tipoSensorCamara, int resolucion, int tamanioPixel) : base(id, marca, modelo, cantDisponible)
        {
            TipoSensorCamara = tipoSensorCamara;
            Resolucion = resolucion;
            TamanioPixel = tamanioPixel;
        }

        public void Update(Camara obj)
        {
            base.Update(obj);
            TipoSensorCamara = obj.TipoSensorCamara;
            Resolucion = obj.Resolucion;
        }

    }
}
