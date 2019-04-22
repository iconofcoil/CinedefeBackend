using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinedefeBackend.Models
{
    public partial class UsuariosRolesView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public string RolPermisos { get; set; }
    }
}
