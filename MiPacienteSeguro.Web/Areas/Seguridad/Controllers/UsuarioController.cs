using MiPacienteSeguro.Dominio.Seguridad;
using MiPacienteSeguro.Web.Areas.Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            Repo.Usuario repositorio = new Repo.Usuario();
            var usuario = repositorio.ConsultarUsuarioPorId(id);
            UsuarioRoles usuarioRoles = new UsuarioRoles();
            usuarioRoles.Usuario = usuario;
            Repo.Rol repositorioRol = new Repo.Rol();
            var roles = repositorioRol.ConsultarRoles();
            Dictionary<Rol, bool> rolesAsignados = new Dictionary<Rol, bool>();
            foreach (var rol in roles)
            {
                if (usuario.Rol.FirstOrDefault(r => r.Id == rol.Id) != null)
                {
                    rolesAsignados.Add(rol, true);
                }
                else
                {
                    rolesAsignados.Add(rol, false);
                }
            }
            usuarioRoles.Roles = rolesAsignados;
            return View(usuarioRoles);
        }

        [HttpPost]
        public ActionResult AsignarRoles(Guid id, FormCollection usuarioRoles)
        {
            Repo.Usuario repositorio = new Repo.Usuario();
            var usuario = repositorio.ConsultarUsuarioPorId(id);
            Repo.Rol repositorioRol = new Repo.Rol();
            var roles = repositorioRol.ConsultarRoles();
            List<Rol> rolesAsignados = new List<Rol>();
            foreach (var rol in roles)
            {
                if (usuarioRoles[rol.Nombre].ToString().Contains("true"))
                {
                    rolesAsignados.Add(rol);   
                }
            }
            usuario.Rol = rolesAsignados;
            repositorio.AsignarRolesUsuario(usuario);
            var usuarios = repositorio.ConsultarUsuarios();

            return RedirectToAction("Index", usuarios);
        }

        public ActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuario(Usuario usuario)
        {

            Repo.Usuario repositorio = new Repo.Usuario();
            var usuarioValidacion = repositorio.ConsultarUsuarioPorNombreDeUsuario(usuario.NombreUsuario);
            

            if (usuarioValidacion == null)
            {
                usuario.Id = Guid.NewGuid();
                repositorio.GuardarUsuario(usuario);
                //return View("Login");
                return Json(new { estado = "Ok", mensaje = "Usuario almacenado", urlNavegacion = "../usuario/login"}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Error = "El usuario ya existe";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Repo.Usuario repositorio = new Repo.Usuario();
            var usuarioValidado = repositorio.ValidarUsuario(usuario.NombreUsuario, usuario.Password);
            if(usuarioValidado != null)
            {
                FormsAuthentication.SetAuthCookie(usuarioValidado.NombreUsuario, false);
                System.Web.HttpContext.Current.User =
                    new GenericPrincipal(new GenericIdentity(usuarioValidado.NombreUsuario),
                        usuarioValidado.Rol.Select(r => r.Nombre).ToArray());
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        public ActionResult ValidarUsuario(string nombreUsuario)
        {
            Repo.Usuario repositorio = new Repo.Usuario();
           
            var usuario = repositorio.ConsultarUsuarioPorNombreDeUsuario(nombreUsuario);
            if (usuario != null)
            {
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { estado = "Ok" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}