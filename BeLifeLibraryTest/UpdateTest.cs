using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeLybreryTest
{
    [TestClass]
    public class UpdateTest
    {

        [TestMethod]
        public void ActualizarTest()
        {
            BelifeLibrary.EstadoCivil estado = new BelifeLibrary.EstadoCivil
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
                Nombres = "Modificado",
                Apellidos = "Modificar",
                FechaNacimiento = DateTime.Parse("17/02/1999"),
                EstadoCivil = estado,
                Sexo = sexo
            };

            BelifeLibrary.Cliente c2 = new BelifeLibrary.Cliente()
            {
                Rut = "29898953-3",
                Nombres = "Modificado",
                Apellidos = "Modificado",
                FechaNacimiento = DateTime.Parse("17/02/1999"),
                EstadoCivil = estado,
                Sexo = sexo
            };

            // Arrange
            var resultadoEsperado = true;

            //Act
            var resultado = c.Update();
            var resultado2 = c.Update();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
            Assert.AreEqual(resultadoEsperado, resultado2);
        }

    }
}
