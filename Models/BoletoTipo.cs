using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class BoletoTipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioActual { get; set; }
    }
}
