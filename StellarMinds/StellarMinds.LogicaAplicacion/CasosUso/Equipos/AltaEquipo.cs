using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class AltaEquipo : ICUAlta<AltaEquipoDto>
    {
        private IRepositorioEquipo _repo;

        public AltaEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }
        public void Ejecutar(AltaEquipoDto obj)
        {
            if (obj == null)
            {
                throw new Exception("El Equipo no puede ser nulo");
            }

            if (obj.TipoEquipo == "Telescopio")
            {
                _repo.Add(new Telescopio(obj.Id, obj.Marca, obj.Modelo, obj.CantDisponible, obj.Apertura.Value, obj.RelacionFocal, obj.DistanciaFocal.Value, obj.Peso.Value));
            }

            if (obj.TipoEquipo == "Ocular")
            {
                _repo.Add(new Ocular(obj.Id, obj.Marca, obj.Modelo, obj.CantDisponible, obj.Diametro.Value, obj.AnguloVision.Value));
            }

            if (obj.TipoEquipo == "Camara")
            {
                _repo.Add(new Camara(obj.Id, obj.Marca, obj.Modelo, obj.CantDisponible, obj.TipoSensorCamara.Value, obj.TamanioPixel.Value, obj.Resolucion.Value));
            }

            if (obj.TipoEquipo == "Montura")
            {
                _repo.Add(new Montura(obj.Id, obj.Marca, obj.Modelo, obj.CantDisponible, obj.TipoMontura.Value, obj.CargaUtilSoportada.Value, obj.Computarizada.Value));
            }
        }

        /* 
if (obj == null)
{
    throw new Exception("El Equipo no puede ser nulo");
}

switch (obj.TipoEquipo)
{
    case "Telescopio":
        _repo.Add(new Telescopio(
            obj.Id,
            obj.Marca,
            obj.Modelo,
            obj.CantDisponible,
            obj.Apertura!.Value,
            obj.RelacionFocal!,
            obj.DistanciaFocal!.Value,
            obj.Peso!.Value
        ));
        break;

    case "Ocular":
        _repo.Add(new Ocular(
            obj.Id,
            obj.Marca,
            obj.Modelo,
            obj.CantDisponible,
            obj.Diametro!.Value,
            obj.AnguloVision!.Value
        ));
        break;

    case "Camara":
        _repo.Add(new Camara(
            obj.Id,
            obj.Marca,
            obj.Modelo,
            obj.CantDisponible,
            obj.TipoSensorCamara!.Value,
            obj.Resolucion!.Value,
            obj.TamanioPixel!.Value
        ));
        break;

    case "Montura":
        _repo.Add(new Montura(
            obj.Id,
            obj.Marca,
            obj.Modelo,
            obj.CantDisponible,
            obj.TipoMontura!.Value,
            obj.CargaUtilSoportada!.Value,
            obj.Computarizada!.Value
        ));
        break;

    default:
        throw new Exception("Tipo de equipo invalido");
}
         */

    }
}
