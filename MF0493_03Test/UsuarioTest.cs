using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF0493_3.Models;

namespace MF0493_3Test
{
    /// <summary>
    /// Summary description for Usuario
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void validarTest()
        {
            Usuario user = new Usuario();
            user.passwdSinCifrar = "123123";

            bool cifrada=user.validar("123123");

            Assert.IsTrue(cifrada);
        }
    }
}
