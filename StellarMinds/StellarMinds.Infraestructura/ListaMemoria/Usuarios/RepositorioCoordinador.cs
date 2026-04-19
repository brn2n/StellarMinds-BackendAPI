using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.ListaMemoria.Usuarios
{
    public class RepositorioSocio : IRepositorioSocio
    {
        private static List<Socio> _usuario { get; set; } = new List<Socio>();
        public void Add(Socio Obj)
        {
            _usuario.Add(Obj);
        }

        public IEnumerable<Socio> GetAll()
        {
            return _usuario;
        }
    }
}
