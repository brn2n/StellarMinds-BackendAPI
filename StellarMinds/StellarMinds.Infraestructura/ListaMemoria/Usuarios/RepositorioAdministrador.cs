using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.ListaMemoria.Usuarios
{
    public class RepositorioAdministrador : IRepositorioAdmin
    {
        private static List<Administrador> _usuario { get; set; } = new List<Administrador>();
        public void Add(Administrador Obj)
        {
            _usuario.Add(Obj);
        }
    }
}
