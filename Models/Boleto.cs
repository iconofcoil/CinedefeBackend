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
        public DateTime Horario { get; set; }

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
        public DateTime Horario { get; set; }


        public BoletoExtended(Boleto boleto)
        {
            Tipo = new BoletoTipo();
            Funcion = new Funcion();
            Cliente = new Cliente();

            this.Id = boleto.Id;
            this.Precio = boleto.Precio;
            this.AsientoFila = boleto.AsientoFila;
            this.AsientoNumero = boleto.AsientoNumero;
            this.Horario = boleto.Horario;
        }
    }
}
