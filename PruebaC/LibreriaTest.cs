using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace PruebaP
{
    [TestClass]
    public class LibreriaTest
    {

        [TestMethod]
        public void SiExistenLibrosReservoYComproElQueNecesito()
        {
            string libro = "Odisea";
            int cantidadLibros = 2;

            var libreria = Mock.Create<Libreria>();
            libreria.Arrange(l => l.LibrosDisponibles(libro)).Returns(10);
            libreria.Arrange(l => l.Reservar(libro, cantidadLibros)).Returns(new List<string> { "L1", "L2" });

            Persona persona = new Persona();
            persona.CompraLibros(libreria, cantidadLibros,libro);

            Assert.IsTrue(persona.ObtuvoLibros);
            libreria.Assert(l => l.LibrosDisponibles(libro));
            libreria.Assert(c => c.Reservar(libro, cantidadLibros));

        }

        [TestMethod]
        public void SiNoExistenLibrosCuandoQuieroComprarEntoncesNoCompro()
        {
            string libro = "Odisea";
            int cantidadLibros = 2;

            var libreria = Mock.Create<Libreria>();
            libreria.Arrange(l => l.LibrosDisponibles(libro)).Returns(0);

            Persona persona = new Persona();
            persona.CompraLibros(libreria, cantidadLibros, libro);

            Assert.IsFalse(persona.ObtuvoLibros);
            libreria.Assert(l => l.LibrosDisponibles(libro));
        }

        [TestMethod]
        public void SiNoExistenTodosLosLibrosQueQuieroComprarEntoncesComproLosQueHayDisponibles()
        {
            string libro = "Cumandá";
            int cantidadLibros = 8;
            int librosDisponibles = 6;

            var libreria = Mock.Create<Libreria>();
            libreria.Arrange(l => l.LibrosDisponibles(libro)).Returns(librosDisponibles);
            libreria.Arrange(l => l.Reservar(libro, 6)).Returns(new List<string> { "L1", "L2", "L3", "L4", "L5", "L6" });

            Persona persona = new Persona();
            persona.CompraLibros(libreria, cantidadLibros, libro);

            Assert.IsTrue(persona.ObtuvoLibros);
            Assert.AreEqual(librosDisponibles, persona.Libros.Count);
            libreria.Assert(c => c.LibrosDisponibles(libro));
            libreria.Assert(c => c.Reservar( libro, librosDisponibles));
        }
      

    }
}
