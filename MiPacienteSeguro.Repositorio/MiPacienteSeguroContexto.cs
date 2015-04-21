using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.Repositorio
{
    public class MiPacienteSeguroContexto : DbContext
    {
        public MiPacienteSeguroContexto() : base("name=MiPaciente")
        {
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;  
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<Opcion> Opciones { get; set; }
    }
}
