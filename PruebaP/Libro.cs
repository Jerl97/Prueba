using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP
{
    public class Libro :ILibro
    {
        public Libro()
        {
        }
        public int PrecioLibro { get; set; }
        public int PrecioTotal { get; set; }

        public int Subtotal(int impuestos)
        {
            return PrecioLibro + impuestos;
        }


        public double TotalLibro()
        {
            return PrecioTotal;
        }
    }
}


