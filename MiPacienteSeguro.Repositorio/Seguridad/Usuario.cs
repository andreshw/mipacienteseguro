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
    }
}
