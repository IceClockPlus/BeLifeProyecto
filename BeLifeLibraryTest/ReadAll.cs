using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeLybreryTest
{
    [TestClass]
    public class ReadAll
    {
        [TestMethod]
        public void BuscarTodosTest()
        {
            List<BelifeLibrary.Cliente> clientes = new List<BelifeLibrary.Cliente>();


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

            clientes.Add(c);
            clientes.Add(c2);
            // Arrange
            var resultadoEsperado = clientes;

            //Act
            var resultado = c.ReadAll();

            //Assert
            System.Object.ReferenceEquals(resultadoEsperado, resultado);
        }

    }
}
