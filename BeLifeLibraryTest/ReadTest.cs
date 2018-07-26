using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeLybreryTest
{
    [TestClass]
    public class ReadTest
    {
        [TestMethod]
        public void BuscarTest()
        {
            BelifeLibrary.EstadoCivil estadoCivil = new BelifeLibrary.EstadoCivil
            {
                Id = 1,
                Descripcion = "Soltero"
            };

            BelifeLibrary.Sexo sexo = new BelifeLibrary.Sexo
            {
                Id = 1,
                Descripcion = "Hombre"
            };

            BelifeLibrary.Cliente c = new BelifeLibrary.Cliente()
            {
                Rut = "19898953-3",
                Nombres = "Jose Ignacio",
                Apellidos = "Estay Contreras",
                FechaNacimiento = DateTime.Parse("1999-02-17 00:00:00.000"),
                EstadoCivil = estadoCivil,
                Sexo = sexo
            };

            BelifeLibrary.Cliente c2 = new BelifeLibrary.Cliente()
            {
                Rut = "29898953-3",
                Nombres = "Jose Ignacio",
                Apellidos = "Estay Contreras",
                FechaNacimiento = DateTime.Parse("1999-02-17 00:00:00.000"),
                EstadoCivil = estadoCivil,
                Sexo = sexo
            };

            // Arrange
            var resultadoEsperado = c;
            var resultadoEsperado2 = c2;

            //Act
            var resultado = c.Read();
            var resultado2 = c2.Read();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
            Assert.AreEqual(resultadoEsperado2, resultado2);
        }
    }
}
