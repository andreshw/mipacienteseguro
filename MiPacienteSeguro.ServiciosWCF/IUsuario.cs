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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        Entidades.Usuario ValidarUsuario(string nombreUsuario);

        [OperationContract]
        void CrearUsuario(Entidades.Usuario usuario);
    }
}
