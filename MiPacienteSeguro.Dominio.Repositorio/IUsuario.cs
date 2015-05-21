using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.Dominio.Repositorio
{
    public interface IUsuario
    {
        List<Entidades.Usuario> ConsultarUsuarios();

        Entidades.Usuario ValidarUsuario(string userName, string password);

        Entidades.Usuario ConsultarUsuarioPorId(Guid idUsuario);

        Entidades.Usuario ConsultarUsuarioPorNombreDeUsuario(string userName);

        void GuardarUsuario(Entidades.Usuario usuario);

        void AsignarRolesUsuario(Entidades.Usuario usuario);
    }
}
