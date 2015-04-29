using MiPacienteSeguro.Repositorio.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPacienteSeguro.Web.Infraestructura
{
    public class MiAutorizacion : AuthorizeAttribute
    {
        private string[] roles;

        public MiAutorizacion(params string[] rolesPermitidos)
        {
            roles = rolesPermitidos;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Usuario repositorio = new Usuario();
            var nombreUsuarioActual = System.Web.HttpContext.Current.User.Identity.Name;
            var usuarioActual = repositorio.ConsultarUsuarioPorNombreDeUsuario(nombreUsuarioActual);

            if (usuarioActual != null)
            {
                foreach (var rol in roles)
                {
                    if (usuarioActual.Rol.FirstOrDefault(r => r.Nombre == rol) != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}