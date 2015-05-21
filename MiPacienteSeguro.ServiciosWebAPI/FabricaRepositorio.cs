using MiPacienteSeguro.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using impl = MiPacienteSeguro.Repositorio.Seguridad;
using implOracle = MiPacienteSeguro.RepositorioOracle.Seguridad;


namespace MiPacienteSeguro.ServiciosWebAPI
{
    public static class FabricaRepositorio
    {
        public static IUsuario CrearRepositorioUsuario()
        {
            return new impl.Usuario();
        }
    }
}