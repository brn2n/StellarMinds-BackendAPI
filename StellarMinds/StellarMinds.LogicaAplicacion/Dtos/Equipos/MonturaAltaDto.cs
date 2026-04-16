using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    internal record MonturaAltaDto(int Id,
                                 string Marca,
                                 string Modelo,
                                 int CantDisponible,
                                 string TipoMontura,
                                 double CargaUtilSoportada,
                                 bool Computarizada)
    {
    }
}
