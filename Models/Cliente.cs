using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
    }
}
