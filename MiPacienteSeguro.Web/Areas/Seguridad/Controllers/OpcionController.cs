using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;
using Repo = MiPacienteSeguro.Repositorio.Seguridad;

namespace MiPacienteSeguro.Web.Areas.Seguridad.Controllers
{
    public class OpcionController : Controller
    {
        // GET: Seguridad/Opcion
        public ActionResult Index()
        {
            Repo.Opcion repositorio = new Repo.Opcion();
            var opciones = repositorio.ConsultarOpciones();
            return View(opciones);
        }

        public ActionResult CrearOpcion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearOpcion(Entidades.Opcion opcion)
        {
            opcion.Id = Guid.NewGuid();
            Repo.Opcion repositorio = new Repo.Opcion();
            repositorio.GuardarOpcion(opcion);
            var opciones = repositorio.ConsultarOpciones();
            return RedirectToAction("Index", opciones);
        }
    }
}