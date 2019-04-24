using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinedefeBackend.Models
{
    public class BoletoTipoFuncion
    {
        public int BoletoTipoId { get; set; }
        public int FuncionId { get; set; }
        public decimal? Precio { get; set; }
    }
}
