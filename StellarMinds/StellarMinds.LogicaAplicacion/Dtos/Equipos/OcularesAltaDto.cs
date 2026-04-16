using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    internal record OcularesAltaDto (int Id,
                                    string Marca,
                                    string Modelo,
                                    int CantDisponible,
                                    double diametro, 
                                    int anguloVision)
    {
    }
}
