using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades = MiPacienteSeguro.Dominio.Seguridad;

namespace MiPacienteSeguro.Repositorio.Seguridad
{
    public class Usuario
    {
        private MiPacienteSeguroContexto _contexto;
        public Usuario() 
        {
            _contexto = new MiPacienteSeguroContexto();
        }

        public List<Entidades.Usuario> ConsultarUsuarios()
        {
            return this._contexto.Usuarios.ToList();
        }

        public Entidades.Usuario ValidarUsuario(string userName, string password)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == userName && u.Password == password);
        }

        public Entidades.Usuario ConsultarUsuarioPorId(Guid idUsuario)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
        }

        public Entidades.Usuario ConsultarUsuarioPorNombreDeUsuario(string userName)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == userName);
        }

        public void GuardarUsuario(Entidades.Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public void AsignarRolesUsuario(Entidades.Usuario usuario)
        {
            using (MiPacienteSeguroContexto contexto = new MiPacienteSeguroContexto())
            {
                var usuarioEditar = contexto.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
                usuarioEditar.Rol.RemoveAll(r => r.Id != null);
                List<Entidades.Rol> rolesAsignados = new List<Entidades.Rol>();
                foreach (var rol in usuario.Rol)
                {
                    rolesAsignados.Add(contexto.Rol.FirstOrDefault(r => r.Id == rol.Id));
                }
                usuarioEditar.Rol = rolesAsignados;
                contexto.SaveChanges();
            }
        }
    }
}
