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

            decimal numeroUno = 20, numeroDos = 5, numeroTres = 2, numeroCuatro = 10;

            decimal numeroEsperado1 = 4, numeroEsperado2 = 10, numeroEsperado3 = 2;

            var metodo = new Metodos();

            //act
            decimal actual1 = metodo.DividirDosNumeros(numeroUno, numeroDos);
            decimal actual2 = metodo.DividirDosNumeros(numeroUno, numeroTres);
            decimal actual3 = metodo.DividirDosNumeros(numeroUno, numeroCuatro);
            decimal actual4 = metodo.DividirDosNumeros(numeroCuatro, numeroDos);



            //assert
            Assert.AreEqual(numeroEsperado1, actual1);
            Assert.AreEqual(numeroEsperado2, actual2);
            Assert.AreEqual(numeroEsperado3, actual3);
            Assert.AreEqual(numeroEsperado3, actual4);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_PorCero_LanzaExcepcion()
        {
            var metodo = new Metodos();
            //arrange
            metodo.DividirDosNumeros(20, 0);
            metodo.DividirDosNumeros(10, 0);
        }
    }
}