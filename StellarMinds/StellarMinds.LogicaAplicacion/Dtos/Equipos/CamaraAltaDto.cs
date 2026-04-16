using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    internal record CamaraAltaDto(int Id,
                                string Marca,
                                string Modelo,
                                int CantDisponible,
                                string TipoSensorCamara,
                                int Resolucion,
                                int TamanioPixel)
    {
    }
}
