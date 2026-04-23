using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios
{
    public interface IRepositorioUsuario : IRepositorioGetAll<Usuario>, IRepositorioAdd<Usuario>
    {

    }
}
