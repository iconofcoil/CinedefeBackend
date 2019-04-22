using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class UsuarioRol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Permisos { get; set; }
    }
}
