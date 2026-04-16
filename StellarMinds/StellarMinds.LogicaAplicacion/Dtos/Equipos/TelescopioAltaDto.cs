using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    internal record TelescopioAltaDto (int Id,
                                      string Marca,
                                      string Modelo,
                                      int CantDisponible,
                                      double apertura, 
                                      string relacionFocal, 
                                      double distanciaFocal, 
                                      double peso)
    {
    }
}
