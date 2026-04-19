using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class ListarUsuarios : ICUGetAll<Usuario>
    {
        private IRepositorioUsuario _repo;

        public ListarUsuarios(IRepositorioUsuario repositorioUsuarios)
        {
            _repo = repositorioUsuarios;
        }
        public IEnumerable<Usuario> Ejecutar()
        {
            return _repo.GetAll();
        }
    }
}
