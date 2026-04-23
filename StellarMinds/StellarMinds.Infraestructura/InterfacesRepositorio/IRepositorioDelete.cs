using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioDelete<T>
    {
        void Delete(int Id);
    }
}
