using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPacienteSeguro.Dominio.Seguridad
{
    [Serializable]
    public class Rol
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<Usuario> Usuario { get; set; }
        public virtual List<Opcion> Opciones { get; set; }
    }
}
