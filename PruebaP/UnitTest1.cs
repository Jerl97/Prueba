using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace PruebaP
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void SiEstaDentroDeMiPrespuestoElLibroCompro()
        {
            var libro = MockRepository.GenerateStub<ILibro>();
            libro.Stub(l => l.TotalLibro()).Return(50);//si el libro est dentro d mi presupeusto compro

            var presupuesto = new Presupuesto();
            presupuesto.Impuesto = 8; 
            presupuesto.Compro(libro);

            Assert.IsTrue(presupuesto.SiCompro);
            libro.AssertWasCalled(l => l.Subtotal(presupuesto.Impuesto));
            libro.AssertWasCalled(l => l.TotalLibro());
            
        }

        [TestMethod]
        public void SiElLibroMasLosImpuestosValeMenosOIgualDeMiPresupuestoSePuedeComprar()
        {           
            var libro = MockRepository.GenerateStub<ILibro>();
            libro.Stub(l => l.TotalLibro()).Return(50);

            libro.PrecioLibro = 25;
            libro.Subtotal(50);

            var presupuesto = new Presupuesto();
            presupuesto.Impuesto = 3;
            presupuesto.Compro(libro);

            Assert.IsTrue(presupuesto.SiCompro);
            libro.AssertWasCalled(l => l.Subtotal(presupuesto.Impuesto));
            libro.AssertWasCalled(l => l.TotalLibro());
        }
        [TestMethod]
        public void SiElLibroMasLosImpuestosSaleDeMiPresupuestoNoPuedoComprar()
        {
            var libro = MockRepository.GenerateStub<ILibro>();
            libro.Stub(l => l.TotalLibro()).Return(50);

            libro.PrecioLibro = 47;
            libro.Subtotal(50);

            var presupuesto = new Presupuesto();
            presupuesto.Impuesto = 6;
            presupuesto.Compro(libro);

            Assert.IsTrue(presupuesto.SiCompro);
            libro.AssertWasCalled(l => l.Subtotal(presupuesto.Impuesto));
            libro.AssertWasCalled(l => l.TotalLibro());
        }

    }
}
