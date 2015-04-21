using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.Repositorio.Seguridad
{
    public class Opcion
    {
        private MiPacienteSeguroContexto _contexto;

        public Opcion()
        {
            _contexto = new MiPacienteSeguroContexto();
        }

        public List<Entidades.Opcion> ConsultarOpciones()
        {
            return _contexto.Opciones.ToList();
        }

        public void GuardarOpcion(Entidades.Opcion opcion)
        {
            _contexto.Opciones.Add(opcion);
            _contexto.SaveChanges();
        }
    }
}
