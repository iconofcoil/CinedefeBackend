using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Activa { get; set; }
        public int SucursalId { get; set; }
        public int TipoId { get; set; }
    }

    public partial class SalaExtended
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Activa { get; set; }
        public Sucursal Sucursal { get; set; }
        public SalaTipo Tipo { get; set; }
        public SalaAsientos Asientos { get; set; }

        public SalaExtended()
        {
            Sucursal = new Sucursal();
            Tipo = new SalaTipo();
            Asientos = new SalaAsientos();
        }

        public SalaExtended(Sala sala)
        {
            Sucursal = new Sucursal();
            Tipo = new SalaTipo();
            Asientos = new SalaAsientos();

            this.Id = sala.Id;
            this.Nombre = sala.Nombre;
            this.Activa = sala.Activa;
            this.Sucursal.Id = sala.SucursalId;
            this.Tipo.Id = sala.TipoId;
        }
    }
}
