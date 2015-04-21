using System.Web.Mvc;

namespace MiPacienteSeguro.Web.Areas.Pacientes
{
    public class PacientesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pacientes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pacientes_default",
                "Pacientes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}