using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPacienteSeguro.Dominio.Seguridad
{
    [Serializable]
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmacionPassword { get; set; }

        [NotMapped]
        public Guid IdRol { get; set; }

        public List<Rol> Rol { get; set; }
    }
}
