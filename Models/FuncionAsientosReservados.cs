using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class FuncionAsientosReservados
    {
        public int FuncionId { get; set; }
        public string AsientoFila { get; set; }
        public short AsientoNumero { get; set; }
    }
}
