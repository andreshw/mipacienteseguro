using MiPacienteSeguro.Web.Areas.Seguridad.Models;
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

        public ActionResult AsignarRoles(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AsignarRoles(UsuarioRoles usuarioRoles)
        {
            return View();
        }
    }
}