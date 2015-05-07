using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MiPacienteSeguro.Dominio.Seguridad;
using Repo = MiPacienteSeguro.Repositorio.Seguridad;

namespace MiPacienteSeguro.Servicios
{
    /// <summary>
    /// Summary description for Pacientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [Serializable]
    public class Pacientes : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
        [WebMethod]
        public Usuario ConsultarUSuarios()
        {
            return new Usuario
            {
                Id = Guid.NewGuid(),
                NombreUsuario = "andreshw",
                Password = "12345"
            };
        }
    }
}
