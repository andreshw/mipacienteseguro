using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo = MiPacienteSeguro.Repositorio.Seguridad;

namespace MiPacienteSeguro.Web.Areas.Seguridad.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            Repo.Usuario usuarioRepositorio = new Repo.Usuario();
            var usuarios = usuarioRepositorio.ConsultarUsuarios();
            return View(usuarios);
        }
    }
}