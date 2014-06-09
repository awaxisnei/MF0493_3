using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF0493_3.Models;

namespace MF0493_3Test
{
    /// <summary>
    /// Summary description for UserManagerTest
    /// </summary>
    [TestClass]
    public class UserManagerTest
    {
       
      [TestMethod]
        public void CrearAdminTest()
        {

            //Creo el administrador
            UserManager.CrearAdmin();
            //Obtengo el administrador.
            Usuario user=UserManager.get("admin");
            Assert.AreEqual(user.username, "admin");
            Assert.AreEqual(user.email, "jucles@a2000.es");

        }

      [TestMethod]
      public void getAllTest()
      {
          List<Usuario> list = new List<Usuario>();
          list=UserManager.getAll();
          Assert.AreEqual(list.Count, 1);

      }

    }
}
