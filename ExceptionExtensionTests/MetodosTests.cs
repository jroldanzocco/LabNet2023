using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExtension.Tests
{
    [TestClass()]
    public class MetodosTests
    {
        [TestMethod()]
        public void DividirDosNumerosTest()
        {
            //arrange

            decimal numeroUno = 20;
            decimal numeroDos = 5;
            decimal numeroEsperado = 4;

            //act
            decimal actual = Metodos.DividirDosNumeros(numeroUno, numeroDos);



            //assert
            Assert.AreEqual(numeroEsperado, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_PorCero_LanzaExcepcion()
        {
            //arrange
            Metodos.DividirDosNumeros(20, 0);
        }
    }
}