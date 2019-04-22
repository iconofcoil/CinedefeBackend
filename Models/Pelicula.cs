using System;
using System.Collections.Generic;

namespace CinedefeBackend.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Direccion { get; set; }
        public int Duracion { get; set; }
        public string Sinopsis { get; set; }
        public int ClasificacionId { get; set; }
        public byte[] Poster { get; set; }
    }

    public partial class PeliculaExtended
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Direccion { get; set; }
        public int Duracion { get; set; }
        public string Sinopsis { get; set; }
        public PeliculaClasificacion Clasificacion { get; set; }
        public byte[] Poster { get; set; }

        public PeliculaExtended()
        {
            Clasificacion = new PeliculaClasificacion();
        }

        public PeliculaExtended(Pelicula pelicula)
        {
            this.Clasificacion = new PeliculaClasificacion();

            this.Id = pelicula.Id;
            this.Titulo = pelicula.Titulo;
            this.Anio = pelicula.Anio;
            this.Direccion = pelicula.Direccion;
            this.Duracion = pelicula.Duracion;
            this.Sinopsis = pelicula.Sinopsis;
            this.Poster = pelicula.Poster;
            this.Clasificacion.Id = pelicula.ClasificacionId;
        }
    }
}
