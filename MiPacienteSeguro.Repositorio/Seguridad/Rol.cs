using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.Repositorio.Seguridad
{
    public class Rol
    {
        private MiPacienteSeguroContexto _contexto;

        public Rol()
        {
            this._contexto = new MiPacienteSeguroContexto();
        }

        public List<Entidades.Rol> ConsultarRoles()
        {
            return this._contexto.Rol.ToList();
        }

        public Entidades.Rol ConsularRolPorId(Guid idRol)
        {
            return _contexto.Rol.FirstOrDefault(r => r.Id == idRol);
        }

        public void GuardarRol(Entidades.Rol rol)
        {
            _contexto.Rol.Add(rol);
            _contexto.SaveChanges();
        }

        public void GuardarOpciones(Entidades.Rol rol)
        {
            using (var contexto = new MiPacienteSeguroContexto())
            {
                var rolEditar = contexto.Rol.FirstOrDefault(r => r.Id == rol.Id);
                rolEditar.Opciones.RemoveAll(o => o.Id != null);

                foreach (var opcion in rol.Opciones)
                {
                    rolEditar.Opciones.Add(contexto.Opciones.FirstOrDefault(o => o.Id == opcion.Id));                    
                }
                contexto.SaveChanges();
            }
            
            
        }
    }
}
