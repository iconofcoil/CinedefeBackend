using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }

        public Sucursal()
        {
        }
    }

    public partial class SucursalExtended
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }

        public SucursalExtended()
        {
            Salas = new List<Sala>();
        }
    }
}
