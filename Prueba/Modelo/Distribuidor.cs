using Prueba.Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo
{
    public class Distribuidor
    {
        public decimal ObtenerPrecioCombustible()
        {
            return 4.50M;
        }

        public void ChequearVehiculo(IVehiculo vehiculo)
        {
            vehiculo.TanqueCombustibleAbierto();
        }
    }
}
