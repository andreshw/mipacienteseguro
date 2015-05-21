using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repo = MiPacienteSeguro.Repositorio.Seguridad;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.ServiciosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public Entidades.Usuario ValidarUsuario(string nombreUsuario)
        {
            Repo.Usuario repositorio = new Repo.Usuario();
            return repositorio.ConsultarUsuarioPorNombreDeUsuario(nombreUsuario);
        }

        public void CrearUsuario(Entidades.Usuario usuario)
        {
            Repo.Usuario repositorio = new Repo.Usuario();
            repositorio.GuardarUsuario(usuario);            
        }
    }
}
