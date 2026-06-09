using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class EquipoMapper
    {
        public static Equipo FromDto(AltaEquipoDto equipoDto)
        {
            if (equipoDto == null)
            {
                throw new ArgumentNullException("El equipo no puede ser null");
            }

            if (equipoDto.TipoEquipo == "Telescopio")
            {
                return new Telescopio(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.Apertura.Value, equipoDto.RelacionFocal, equipoDto.DistanciaFocal.Value, equipoDto.Peso.Value);
            }

            if (equipoDto.TipoEquipo == "Ocular")
            {
                return new Ocular(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.Diametro.Value, equipoDto.AnguloVision.Value);
            }

            if (equipoDto.TipoEquipo == "Camara")
            {
                return new Camara(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.TipoSensorCamara.Value, equipoDto.TamanioPixel.Value, equipoDto.Resolucion.Value);
            }

            if (equipoDto.TipoEquipo == "Montura")
            {
                return new Montura(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.TipoMontura.Value, equipoDto.CargaUtilSoportada.Value, equipoDto.Computarizada.Value);
            }
            return null;
        }

        public static Equipo FromDto(ListarEquipoDto equipoDto)
        {
            if (equipoDto == null)
            {
                throw new ArgumentNullException("El equipo no puede ser null");
            }

            if (equipoDto.TipoEquipo == "Telescopio")
            {
                return new Telescopio(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.Apertura.Value, equipoDto.RelacionFocal, equipoDto.DistanciaFocal.Value, equipoDto.Peso.Value);
            }

            if (equipoDto.TipoEquipo == "Ocular")
            {
                return new Ocular(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.Diametro.Value, equipoDto.AnguloVision.Value);
            }

            if (equipoDto.TipoEquipo == "Camara")
            {
                return new Camara(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.TipoSensorCamara.Value, equipoDto.TamanioPixel.Value, equipoDto.Resolucion.Value);
            }

            if (equipoDto.TipoEquipo == "Montura")
            {
                return new Montura(equipoDto.Marca, equipoDto.Modelo, equipoDto.CantDisponible, equipoDto.TipoMontura.Value, equipoDto.CargaUtilSoportada.Value, equipoDto.Computarizada.Value);
            }
            return null;
        }


        public static ListarEquipoDto toDto(Equipo equipo)
        {
            if (equipo == null) throw new ArgumentNullException(nameof(equipo));

            // Telescopio
            if (equipo is Telescopio t)
            {
                return new ListarEquipoDto(
                t.Id,
                "Telescopio",
                t.Marca,
                t.Modelo,
                t.CantDisponible,
                t.Apertura,
                t.RelacionFocal,
                t.DistanciaFocal,
                t.Peso,
                null, // TipoMontura
                null, // CargaUtilSoportada
                null, // Computarizada
                null, // TipoSensorCamara
                null, // Resolucion
                null, // TamanioPixel
                null, // Diametro
                null  // AnguloVision
            );
            }

            // Ocular
            if (equipo is Ocular o)
            {
                return new ListarEquipoDto(
                    o.Id,
                    "Ocular",
                    o.Marca,
                    o.Modelo,
                    o.CantDisponible,
                    null, // Apertura
                    null, // RelacionFocal
                    null, // DistanciaFocal
                    null, // Peso
                    null, // TipoMontura
                    null, // CargaUtilSoportada
                    null, // Computarizada
                    null, // TipoSensorCamara
                    null, // Resolucion
                    null, // TamanioPixel
                    o.Diametro,
                    o.AnguloVision
                );
            }

            // Camara
            if (equipo is Camara c)
            {
                return new ListarEquipoDto(
                    c.Id,
                    "Camara",
                    c.Marca,
                    c.Modelo,
                    c.CantDisponible,
                    null, // Apertura
                    null, // RelacionFocal
                    null, // DistanciaFocal
                    null, // Peso
                    null, // TipoMontura
                    null, // CargaUtilSoportada
                    null, // Computarizada
                    c.TipoSensorCamara,
                    c.Resolucion,
                    c.TamanioPixel,
                    null, // Diametro
                    null  // AnguloVision
                );
            }

            // Montura
            if (equipo is Montura m)
            {
                return new ListarEquipoDto(
                    m.Id,
                    "Montura",
                    m.Marca,
                    m.Modelo,
                    m.CantDisponible,
                    null, // Apertura
                    null, // RelacionFocal
                    null, // DistanciaFocal
                    null, // Peso
                    m.TipoMontura,
                    m.CargaUtilSoportada,
                    m.Computarizada,
                    null, // TipoSensorCamara
                    null, // Resolucion
                    null, // TamanioPixel
                    null, // Diametro
                    null  // AnguloVision
                );
            }

            throw new ArgumentException("Tipo de equipo desconocido", nameof(equipo));
        }

        public static IEnumerable<ListarEquipoDto> ToListDto(IEnumerable<Equipo> equipos)
        {
            List<ListarEquipoDto> aux = new List<ListarEquipoDto>();
            foreach (Equipo item in equipos)
            {
                aux.Add(toDto(item));
            }
            return aux;
        }
    }
}
