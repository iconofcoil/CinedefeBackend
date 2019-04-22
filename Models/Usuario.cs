using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }

    public partial class UsuarioPost
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }
}
