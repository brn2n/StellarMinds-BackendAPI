using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.ListaMemoria.Usuarios
{
    public class RepositorioCoordinador : IRepositorioCoordinador
    {
        private static List<Coordinador> _usuario { get; set; } = new List<Coordinador>();
        public void Add(Coordinador Obj)
        {
            _usuario.Add(Obj);
        }
    }
}
