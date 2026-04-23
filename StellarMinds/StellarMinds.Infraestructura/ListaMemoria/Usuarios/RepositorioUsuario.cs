using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> _usuario { get; set; } = new List<Usuario>();

        public void Add(Usuario Obj)
        {
            _usuario.Add(Obj);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuario;
        }
    }
}
