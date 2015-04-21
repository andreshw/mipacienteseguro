using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPacienteSeguro.Dominio.Seguridad
{
    public class Opcion
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public virtual List<Rol> Roles { get; set; }
    }
}
