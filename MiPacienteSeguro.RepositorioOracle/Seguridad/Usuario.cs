using MiPacienteSeguro.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPacienteSeguro.RepositorioOracle.Seguridad
{
    public class Usuario : IUsuario
    {
        public List<MiPacienteSeguro.Dominio.Seguridad.Usuario> ConsultarUsuarios()
        {
            throw new NotImplementedException();
        }

        public MiPacienteSeguro.Dominio.Seguridad.Usuario ValidarUsuario(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public MiPacienteSeguro.Dominio.Seguridad.Usuario ConsultarUsuarioPorId(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public MiPacienteSeguro.Dominio.Seguridad.Usuario ConsultarUsuarioPorNombreDeUsuario(string userName)
        {
            throw new NotImplementedException();
        }

        public void GuardarUsuario(MiPacienteSeguro.Dominio.Seguridad.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void AsignarRolesUsuario(MiPacienteSeguro.Dominio.Seguridad.Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
