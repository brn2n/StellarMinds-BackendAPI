using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes
{
    public class ListarObjetosCelestes : ICUGetAll<ListarObjetoCelesteDto>
    {
        private readonly IRepositorioObjetosCelestes _repo;

        public ListarObjetosCelestes(IRepositorioObjetosCelestes repo)
        {
            _repo = repo;
        }

        public IEnumerable<ListarObjetoCelesteDto> Ejecutar()
        {
            return _repo.GetAll()
                .Select(o => new ListarObjetoCelesteDto(
                    o.Id,
                    o.Nombre,
                    o.Tipo
                ));
        }
    }
}
