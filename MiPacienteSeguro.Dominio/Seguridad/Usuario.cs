using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MiPacienteSeguro.Dominio.Seguridad
{
    [Serializable]
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string NombreUsuario { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [NotMapped]
        [DataMember]
        [Compare("Password")]
        public string ConfirmacionPassword { get; set; }

        [NotMapped]
        [DataMember]
        public Guid IdRol { get; set; }
        
        [DataMember]
        public List<Rol> Rol { get; set; }
    }
}
