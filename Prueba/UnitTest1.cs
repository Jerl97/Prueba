using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prueba.Modelo;
using Prueba.Modelo.Interfaces;
using System;

namespace Prueba
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SiElVehiculoSeEncuentraEnBuenEstadoAunSirve()
        {
            var distribuidor = A.Fake<Distribuidor>();
            var carro = A.Fake<Carro>(x => x.WithArgumentsForConstructor(() => new Carro("WB 82112")));
            var estacionGasolina = A.Fake<EstacionGasolina>();
            var transaccion = A.Fake<Transaccion>();
            var vehiculo = A.Fake<IVehiculo>();

            transaccion.PrecioTotalCombustible(distribuidor, 4);

            A.CallTo(() => distribuidor.ObtenerPrecioCombustible()).MustHaveHappenedOnceExactly();
            A.CallTo(() => transaccion.Terminado()).DoesNothing();

            A.CallTo(() => vehiculo.EstadoMotor()).Throws<NotImplementedException>();

            try
            {
                vehiculo.EstadoMotor();
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
                Assert.AreEqual(exceptionType, typeof(NotImplementedException));
            }

            distribuidor.ChequearVehiculo(A.Dummy<IVehiculo>());


            A.CallTo(() => distribuidor.ObtenerPrecioCombustible()).Returns(4.5M).Once();
            var precioCombustible = distribuidor.ObtenerPrecioCombustible();

            Assert.AreNotEqual(precioCombustible, 0);
        }
    }
}
