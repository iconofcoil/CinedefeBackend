using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinedefeBackend.Models
{
    public class FuncionDisponibleView
    {
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public string PeliculaTitulo { get; set; }
        public byte[] PeliculaPoster { get; set; }
        public int PeliculaDuracion { get; set; }
        public string PeliculaClasificacion { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public string SalaTipo { get; set; }
        public int SucursalId { get; set; }

    }
}
