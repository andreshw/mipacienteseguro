using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repo = MiPacienteSeguro.Dominio.Repositorio;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.ServiciosWebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        public IEnumerable<Entidades.Usuario> Get()
        {
            Repo.IUsuario repositorio = FabricaRepositorio.CrearRepositorioUsuario();
            return repositorio.ConsultarUsuarios();
        }

        public Entidades.Usuario Get(string nombreUuario)
        {
            Repo.IUsuario repositorio = FabricaRepositorio.CrearRepositorioUsuario();
            return repositorio.ConsultarUsuarioPorNombreDeUsuario(nombreUuario);
        }
    }
}
