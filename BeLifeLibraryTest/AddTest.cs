using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BeLifeLybreryTest
{
    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void AgregarTest()
        {
            // Arrange
            bool resultadoEsperado = false; // true = Cliente agregado / false = No se pudo agregar cliente 

            var _rut = "19898953-3";
            var _nombres = "Jose Ignacio";
            var _apellidos = "Estay Contreras";
            var _fechaNacimiento = DateTime.Parse("17-02-1998");

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


            BelifeLibrary.Cliente cl = new BelifeLibrary.Cliente()
            {
                Rut = _rut,
                Nombres = _nombres,
                Apellidos = _apellidos,
                FechaNacimiento = _fechaNacimiento,
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


            //Act
            var resultado = cl.Agregar();
            var resultado2 = c2.Agregar();


            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
            Assert.AreEqual(resultadoEsperado, resultado2);
        }
    }
}
