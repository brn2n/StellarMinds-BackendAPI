using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class ObjetoCelesteMapper
    {
        public static RankingObjetosPorSocioDto toDto(ObjetoCeleste objeto, int cantidad)
        {
            if (objeto == null) throw new ArgumentNullException(nameof(objeto));

            return new RankingObjetosPorSocioDto(objeto.Nombre, objeto.Tipo, cantidad);
        }

        public static IEnumerable<RankingObjetosPorSocioDto> ToListDto(IEnumerable<(ObjetoCeleste objeto, int cantidad)> lista)
        {
            List<RankingObjetosPorSocioDto> aux = new List<RankingObjetosPorSocioDto>();
            foreach (var item in lista)
            {
                aux.Add(toDto(item.objeto, item.cantidad));
            }
            return aux;
        }

        internal static ListarObjetoCelesteDto ToDto(ObjetoCeleste objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            return new ListarObjetoCelesteDto(
                objeto.Id,
                objeto.Nombre,
                objeto.Tipo.ToString()
            );
        }
    }
}
