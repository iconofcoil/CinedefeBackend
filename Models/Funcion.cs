using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Funcion
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public int PeliculaId { get; set; }
        public byte Activa { get; set; }
    }

    public partial class FuncionExtended
    {
        public int Id { get; set; }
        public Sala Sala { get; set; }
        public Pelicula Pelicula { get; set; }
        public byte Activa { get; set; }

        public FuncionExtended()
        {
            Sala = new Sala();
            Pelicula = new Pelicula();
        }

        public FuncionExtended(Funcion funcion)
        {
            Sala = new Sala();
            Pelicula = new Pelicula();

            this.Id = funcion.Id;
            this.Sala.Id = funcion.SalaId;
            this.Pelicula.Id = funcion.PeliculaId;
            this.Activa = funcion.Activa;
        }
    }
}
