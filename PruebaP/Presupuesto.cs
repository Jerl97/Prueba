using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP
{
    internal class Presupuesto
    {
        public Presupuesto()
        {
        }
        

        public int Impuesto { get; set; }
        public bool SiCompro { get; set; }

        internal void Compro(ILibro libro)
        {
            if (libro.TotalLibro() <= 50)
            {
                libro.Subtotal(this.Impuesto);
                this.SiCompro = true;
            }
            else
            {
                this.SiCompro = false;
            }
        }
    }
}
