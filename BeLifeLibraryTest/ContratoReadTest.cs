//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeLifeLybreryTest
//{
//    [TestClass]
//    public class ContratoReadTest
//    {
//        [TestMethod]
//        public void ContratoBuscarTest()
//        {
//            // Arrange
//            string _numero = "20180521";
//            string _numero2 = "20190521";
//            DateTime _creacion = DateTime.Today.AddMonths(+1);
//            DateTime _termino = DateTime.Today.AddMonths(+2);
//            DateTime _inicioVigencia = DateTime.Today.AddMonths(+1);
//            DateTime _finVigencia = DateTime.Today.AddMonths(+1);
//            bool _estaVigente = true;
//            bool _conDeclaracionSalud = true;
//            string _observaciones = "El cliente sadjsadhsajdasjdh xd";

//            /* con estos rut buscaremos a los clientes registrados en la base de datos*/
//            string _rut1 = "19898953-3";
//            string _rut2 = "29898953-3";

//            BelifeLibrary.Cliente c1 = new BelifeLibrary.Cliente()
//            {
//                Rut = _rut1
//            };

//            BelifeLibrary.Cliente c2 = new BelifeLibrary.Cliente()
//            {
//                Rut = _rut2
//            };

//            BelifeLibrary.Plan plan1 = new BelifeLibrary.Plan()
//            {
//                Id = "VID01",
//                Nombre = "Vida Inicial",
//                PrimaBase = 0.5,
//                PolizaActual = "POL120113229"
//            };

//            BelifeLibrary.Plan plan2 = new BelifeLibrary.Plan()
//            {
//                Id = "VID02",
//                Nombre = "Vida Total",
//                PrimaBase = 3.5,
//                PolizaActual = "POL120648575"
//            };

//            //Act
//            var buscarCliente1 = c1.Read();
//            var buscarCliente2 = c2.Read();

//            BelifeLibrary.Contrato contrato1 = new BelifeLibrary.Contrato()
//            {
//                Numero = _numero,
//                Creacion = DateTime.Today.AddMonths(+1),
//                Termino = DateTime.Today.AddMonths(+2),
//                Titular = c1,
//                PlanAsociado = plan1,
//                Poliza = plan1.PolizaActual,
//                InicioVigencia = DateTime.Today.AddMonths(+1),
//                FinVigencia = DateTime.Today.AddMonths(+1),
//                EstaVigente = _estaVigente,
//                ConDeclaracionDeSalud = _conDeclaracionSalud,
//                PrimaAnual = (float)(plan1.PrimaBase * 12),
//                PrimaMensual = (float)(plan1.PrimaBase),
//                Observaciones = _observaciones
//            };

//            BelifeLibrary.Contrato contrato2 = new BelifeLibrary.Contrato()
//            {
//                Numero = _numero2,
//                Creacion = _creacion,
//                Termino = _termino,
//                Titular = c2,
//                PlanAsociado = plan2,
//                Poliza = plan2.PolizaActual,
//                InicioVigencia = _inicioVigencia,
//                FinVigencia = _finVigencia,
//                EstaVigente = _estaVigente,
//                ConDeclaracionDeSalud = _conDeclaracionSalud,
//                PrimaAnual = (float)(plan2.PrimaBase * 12),
//                PrimaMensual = (float)(plan2.PrimaBase),
//                Observaciones = _observaciones
//            };

//            // Arrange
//            var resultadoEsperado1 = contrato1;
//            var resultadoEsperado2 = contrato2;

//            //Act
//            var resultado = contrato1.Read();
//            var resultado2 = contrato2.Read();

//            //Assert
//            Assert.AreEqual(resultadoEsperado1, resultado);
//            //Assert.AreEqual(resultadoEsperado2, resultado2);
//        }
//    }
//}
