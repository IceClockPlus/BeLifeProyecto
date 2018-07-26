//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeLifeLybreryTest
//{
//    [TestClass]
//    public class DeleteTest
//    {
//        [TestMethod]
//        public void EliminarTest()
//        {
//            BelifeLibrary.Cliente c = new BelifeLibrary.Cliente()
//            {
//                Rut = "19898953-3",
//            };

//            BelifeLibrary.Cliente c2 = new BelifeLibrary.Cliente()
//            {
//                Rut = "29898953-3",
//            };

//            Arrange
//           var resultadoEsperado = true;

//            Act
//            var resultado = c.Delete();
//            var resultado2 = c2.Delete();

//            Assert
//            Assert.AreEqual(resultadoEsperado, resultado);
//            Assert.AreEqual(resultadoEsperado, resultado2);
//        }
//    }
//}
