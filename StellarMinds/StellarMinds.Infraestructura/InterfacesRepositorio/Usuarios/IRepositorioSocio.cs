using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioSocio : IRepositorioAdd<Socio>, IRepositorioGetAll<Socio>
    {

    }
}
