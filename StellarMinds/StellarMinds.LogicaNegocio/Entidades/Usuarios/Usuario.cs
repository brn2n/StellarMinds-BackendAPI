using StellarMinds.LogicaNegocio.VO;
using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public VONombreCompleto NombreCompleto { get; set; }
        public VOTelefono Telefono { get; set; }
        public VOUsername Username { get; set; }
        public VOPassword VOPassword { get; set; }

        private Usuario()
        {
        }

        protected Usuario(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Telefono = telefono;
            Username = username;
            VOPassword = vOPassword;
        }
    }
}
