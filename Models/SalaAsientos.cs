using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class SalaAsientos
    {
        public int SalaId { get; set; }
        public string Fila { get; set; }
        public int Asientos { get; set; }
    }
}
