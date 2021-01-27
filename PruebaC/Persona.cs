using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaP
{
    internal class Persona
    {
        public bool ObtuvoLibros { get{ return Libros != null && Libros.Any(); } }
        public List<string> Libros { get; internal set; }

        
        internal void CompraLibros(Libreria libreria, int cantidadLibros, string libro)
        {
            var librosDisponibles = libreria.LibrosDisponibles(libro);

            if (librosDisponibles >= cantidadLibros)
            {
                Libros= libreria.Reservar(libro, cantidadLibros);

            }
            else
            {
                Libros = libreria.Reservar(libro, librosDisponibles);
            }
        }

       
    }
}