using StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class NocheObservacionMapper
    {
        public static AltaObservacionDto toDto(NocheObservacion noche)
        {
            if (noche == null) throw new ArgumentNullException(nameof(noche));

            return new AltaObservacionDto(noche.Id, noche.PrestamoId, noche.ObjetoCelesteId, noche.FechaObservacion);

            throw new ArgumentException("Tipo de equipo desconocido", nameof(noche));
        }
    }
}
