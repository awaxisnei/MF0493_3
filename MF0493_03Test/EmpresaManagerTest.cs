using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MF0493_3.Models;

namespace MF0493_3Test
{
    /// <summary>
    /// Summary description for EmpresaManagerTest
    /// </summary>
    [TestClass]
    public class EmpresaManagerTest
    {
        [TestMethod]
        public void NuevaTest()
        {
            //Creamos una nueva empresa
            Empresa emp = new Empresa();
            emp.activa = true;
            emp.email = "prueba@gmail.com";
            emp.ff = DateTime.Now;
            emp.logo = "prueba";
            emp.nif = "75258966";
            emp.nombre = "empresaPrueba";
            emp.poblacion = "almeria";
            emp.telefono = "6502824";
            emp.usr = "admin";

            //Se añade una nueva empresa
            EmpresaManager.Nueva(emp);
            
            //consultamos una empresa
            Empresa empresaBuscada=EmpresaManager.get(emp.nif);

            //PRUEBA 1
            Assert.AreEqual(empresaBuscada.nombre, "empresaPrueba");
            //PRUEBA 2
            Assert.AreEqual(empresaBuscada.poblacion, "almeria");

            //Eliminamos la empresa
            EmpresaManager.Eliminar(emp.nif);


        }

        [TestMethod]
        public void ModificarTest()
        {
            //Creamos una nueva empresa
            Empresa emp = new Empresa();
            emp.activa = true;
            emp.email = "pruebaModificar@gmail.com";
            emp.ff = DateTime.Now;
            emp.logo = "pruebaModificar";
            emp.nif = "69696969";
            emp.nombre = "empresaPruebaModificar";
            emp.poblacion = "almeriaModificar";
            emp.telefono = "69696969";
            emp.usr = "admin";

            //Se añade una nueva empresa
            EmpresaManager.Nueva(emp);

             //consultamos una empresa
            Empresa empresaBuscada=EmpresaManager.get(emp.nif);

            //PRUEBA 1 - Comprobacion de inserción correcta
            Assert.AreEqual(empresaBuscada.nombre, "empresaPruebaModificar");
            //PRUEBA 2
            Assert.AreEqual(empresaBuscada.poblacion, "almeriaModificar");

            //Modificamos
            emp.nombre = "nombreModificadoooo";
            emp.poblacion = "granadaModificadaaaa";

            //consultamos una empresa
            bool mod = EmpresaManager.Modificar(emp);

             //consultamos una empresa
            Empresa empresaBuscadaModificada=EmpresaManager.get(emp.nif);

            Assert.IsTrue(mod);
            Assert.AreEqual(empresaBuscadaModificada.nombre, "nombreModificadoooo");
            Assert.AreEqual(empresaBuscadaModificada.poblacion, "granadaModificadaaaa");

            bool eliminado = EmpresaManager.Eliminar("69696969");

        }

        [TestMethod]
        public void GetTest()
        {
            //Creamos una nueva empresa
            Empresa emp = new Empresa();
            emp.activa = true;
            emp.email = "pruebaGet@gmail.com";
            emp.ff = DateTime.Now;
            emp.logo = "pruebaGet";
            emp.nif = "888";
            emp.nombre = "empresaPruebaGet";
            emp.poblacion = "almeriaGet";
            emp.telefono = "69696969";
            emp.usr = "admin";

            //Se añade una nueva empresa
            EmpresaManager.Nueva(emp);

            //consultamos una empresa
            Empresa empresaBuscada = EmpresaManager.get(emp.nif);


            //PRUEBA 1 - Comprobacion de inserción correcta
            Assert.AreEqual(empresaBuscada.nombre, "empresaPruebaGet");
            //PRUEBA 2
            Assert.AreEqual(empresaBuscada.poblacion, "almeriaGet");


        }

        [TestMethod]
        public void EliminarTest()
        {
            bool eliminado=EmpresaManager.Eliminar("888");

            Assert.IsTrue(eliminado);
        }
    }
}
