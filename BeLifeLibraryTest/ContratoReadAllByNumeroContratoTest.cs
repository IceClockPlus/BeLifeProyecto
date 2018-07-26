using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeLybreryTest
{
    [TestClass]
    public class ContratoReadAllByNumeroContratoTest
    {
        [TestMethod]

        public void ContratoBuscarTodosByNumeroTest()
        {
            List<BelifeLibrary.Contrato> contratos = new List<BelifeLibrary.Contrato>();

            // Arrange
            var resultadoEsperado = true; 
            var resultado1 = true;

            string _numero = "20180521";
            DateTime _creacion = DateTime.Today.AddMonths(+1);
            DateTime _termino = DateTime.Today.AddMonths(+2);
            DateTime _inicioVigencia = DateTime.Today.AddMonths(+1);
            DateTime _finVigencia = DateTime.Today.AddMonths(+1);
            bool _estaVigente = true;
            bool _conDeclaracionSalud = true;
            string _observaciones = "El cliente sadjsadhsajdasjdh xd";

            /* con estos rut buscaremos a los clientes registrados en la base de datos*/
            string _rut1 = "19898953-3";

            BelifeLibrary.Cliente c1 = new BelifeLibrary.Cliente()
            {
                Rut = _rut1
            };


            BelifeLibrary.Plan plan1 = new BelifeLibrary.Plan()
            {
                Id = "VID01",
                Nombre = "Vida Inicial",
                PrimaBase = 0.5,
                PolizaActual = "POL120113229"
            };


            //Act
            var buscarCliente1 = c1.Read();

            BelifeLibrary.Contrato contrato1 = new BelifeLibrary.Contrato()
            {
                Numero = _numero,
                Creacion = DateTime.Today.AddMonths(+1),
                Termino = DateTime.Today.AddMonths(+2),
                Titular = buscarCliente1,
                PlanAsociado = plan1,
                Poliza = plan1.PolizaActual,
                InicioVigencia = DateTime.Today.AddMonths(+1),
                FinVigencia = DateTime.Today.AddMonths(+1),
                EstaVigente = _estaVigente,
                ConDeclaracionDeSalud = _conDeclaracionSalud,
                PrimaAnual = (float)(plan1.PrimaBase * 12),
                PrimaMensual = (float)(plan1.PrimaBase),
                Observaciones = _observaciones
            };

            contratos.Add(contrato1);

            var lista1 = contrato1.ReadAllByNumeroContrato();

            for (int i = 0; i < lista1.Count; i++)
            {
                if (lista1[i].Numero == contratos[i].Numero) {
                    resultado1 = true; 
                }
            }

            Assert.AreEqual(resultadoEsperado,resultado1);
        }
    }
}
