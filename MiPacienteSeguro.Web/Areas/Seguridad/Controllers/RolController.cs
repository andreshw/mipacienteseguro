using MiPacienteSeguro.Web.Areas.Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;
using Repo = MiPacienteSeguro.Repositorio.Seguridad;

namespace MiPacienteSeguro.Web.Areas.Seguridad.Controllers
{
    public class RolController : Controller
    {
        // GET: Seguridad/Rol
        public ActionResult Index()
        {
            Repo.Rol repositorio = new Repo.Rol();
            var roles = repositorio.ConsultarRoles();
            return View(roles);
        }

        public ActionResult CrearRol()
        {
            return View();
        }

        public ActionResult AsignarPermisos(Guid id)
        {
            Repo.Rol repositorio = new Repo.Rol();
            var rol = repositorio.ConsularRolPorId(id);
            RolOpciones rolOpciones = new RolOpciones();
            rolOpciones.Rol = rol;
            rolOpciones.Opciones = new Dictionary<Entidades.Opcion, bool>();
            
            Repo.Opcion repositorioOpciones = new Repo.Opcion();
            var opciones = repositorioOpciones.ConsultarOpciones();
            
            foreach (var opcion in opciones)
	        {
		        if(rol.Opciones.FirstOrDefault(o => o.Id == opcion.Id) != null)
                {
                    rolOpciones.Opciones.Add(opcion, true);        
                }
                else
                {
                    rolOpciones.Opciones.Add(opcion, false);        
                }
	        }

            return View(rolOpciones);
        }

        [HttpPost]  
        public ActionResult AsignarPermisos(Guid id, FormCollection postedForm)
        {
            Repo.Rol repositorio = new Repo.Rol();
            var rol = repositorio.ConsularRolPorId(id);
            Repo.Opcion repositorioOpciones = new Repo.Opcion();
            var opciones = repositorioOpciones.ConsultarOpciones();
            List<Entidades.Opcion> opcionesSeleccionadas = new List<Entidades.Opcion>();
            

            foreach (var opcion in opciones)
            {
                if (postedForm[opcion.Nombre].ToString().Contains("true"))
                {
                    opcionesSeleccionadas.Add(opcion);
                }
            }

            rol.Opciones = opcionesSeleccionadas;
            repositorio.GuardarOpciones(rol);

            return Content("prueba");
        }

        [HttpPost]
        public ActionResult CrearRol(Entidades.Rol rol)
        {
            rol.Id = Guid.NewGuid();
            Repo.Rol repositorio = new Repo.Rol();
            repositorio.GuardarRol(rol);
            var roles = repositorio.ConsultarRoles();
            return RedirectToAction("Index", roles);
        }
    }
}