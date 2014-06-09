using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MF0493_3.Models
{
    public class EmpresaManager
    {

        public static Empresa get(string nif)
        {
            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from empresa in db.Empresas
                           where empresa.nif == nif
                           select empresa;

                if (data.Count() == 0) return null;
                else return data.First();
            }
        }
        public static List<Empresa> getAll()
        {
            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from empresa in db.Empresas                           
                           select empresa;
                
                return data.ToList();
            }
        }
        public static bool Nueva(Empresa emp)
        {
            if (emp == null) return false;

            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from empresa in db.Empresas
                           where empresa.nif == emp.nif
                           select empresa;

                if (data.Count() == 0)
                {
                    db.Empresas.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        }
        public static bool Modificar(Empresa emp)
        {
            if (emp == null) return false;

            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from empresa in db.Empresas
                           where empresa.nif == emp.nif
                           select empresa;

                if (data.Count() == 0)
                {
                    db.Empresas.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    Empresa e = data.First();

                    e.nombre = emp.nombre;
                    e.poblacion = emp.poblacion;
                    e.telefono = emp.telefono;
                    e.logo = emp.logo;
                    e.activa = emp.activa;
                    e.email = emp.email;
                    db.SaveChanges();
                    return true;
                }
            } 
        }
        public static bool Eliminar(string nif)
        {
            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from empresa in db.Empresas
                           where empresa.nif == nif
                           select empresa;

                if (data.Count() != 0)
                {
                    db.Empresas.Remove(data.First());
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        }
    }
}