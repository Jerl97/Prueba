using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo
{
    public class Transaccion
    {
        private bool isCompleted;
        public decimal PrecioTotalCombustible(Distribuidor distribuidor, int litros)
        {
            return litros * distribuidor.ObtenerPrecioCombustible();
        }

        public void Terminado()
        {
            isCompleted = true;
        }
    }
}
