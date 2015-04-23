using MiPacienteSeguro.Dominio.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPacienteSeguro.Web.Areas.Seguridad.Models
{
    public class UsuarioRoles
    {
        public Usuario Usuario { get; set; }
        public Dictionary<Rol, bool> Roles { get; set; }
    }
}