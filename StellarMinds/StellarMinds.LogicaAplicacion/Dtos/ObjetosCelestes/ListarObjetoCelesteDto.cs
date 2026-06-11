using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes
{
    public record ListarObjetoCelesteDto(
        int Id,
        string Nombre,
        string Tipo
    );
}
