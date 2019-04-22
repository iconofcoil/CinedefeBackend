using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Boleto
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int FuncionId { get; set; }
        public int ClienteId { get; set; }
        public decimal Precio { get; set; }
        public string AsientoFila { get; set; }
        public short AsientoNumero { get; set; }
    }

    public partial class BoletoExtended
    {
        public int Id { get; set; }
        public BoletoTipo Tipo { get; set; }
        public Funcion Funcion { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Precio { get; set; }
        public string AsientoFila { get; set; }
        public short AsientoNumero { get; set; }

        public BoletoExtended()
        {
            Tipo = new BoletoTipo();
            Funcion = new Funcion();
            Cliente = new Cliente();
        }
    }
}
