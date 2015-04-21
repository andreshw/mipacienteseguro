using MiPacienteSeguro.Dominio.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPacienteSeguro.Web.Areas.Seguridad.Models
{
    public class RolOpciones
    {
        public Rol Rol { set; get; }
        public Dictionary<Opcion, bool> Opciones { set; get; }
    }
}