using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CinedefeBackend.Models;

namespace CinedefeBackend.Models
{
    public class UsuarioExtended
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public UsuarioRol Rol { get; set; }

        public UsuarioExtended()
        {

        }

        public UsuarioExtended(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nombre = usuario.Nombre;
            this.Email = usuario.Email;
            this.Rol = new UsuarioRol();
            this.Rol.Id = usuario.RolId;
        }
    }
}
