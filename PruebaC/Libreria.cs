using System;
using System.Collections.Generic;

namespace PruebaP
{
    public abstract class Libreria
    {
        public abstract int LibrosDisponibles(string libro);

        public abstract List<string> Reservar(string libro, int cantidadEntrada);
    }
}