using Prueba.Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo
{

    public class Carro : IVehiculo
    {
        private string numeroPlaca;
        public string NumeroPlaca => numeroPlaca;

        public Carro(string numeroPlaca)
        {
            this.numeroPlaca = numeroPlaca;
        }

        public void EstadoMotor()
        {
            Console.WriteLine("Motor en Buen Estado");
        }

        public void TanqueCombustibleAbierto()
        {
            Console.WriteLine("Abierto Tanque de Combustible");
        }
    }
}
