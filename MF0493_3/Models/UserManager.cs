using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MF0493_3.Models
{
    public class UserManager
    {

        public static Usuario get(string username)
        {
            MF0493Entities db = new MF0493Entities();
            var data = from usuarios in db.Usuarios
                       where usuarios.username == username
                       select usuarios;

            if (data.Count() == 0) return null;
            else return data.First();

        }
        public static List<Usuario> getAll()
        {
            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from usuarios in db.Usuarios
                           select usuarios;

                return data.ToList();
            }
        }

        public static bool NuevoUsuario(Usuario u)
        {

            if (u == null) return false;

            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from usuarios in db.Usuarios
                           where usuarios.username == u.username
                           select usuarios;

                if (data.Count() == 0)
                {
                    db.Usuarios.Add(u);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
        public static void CrearAdmin()
        {
            using (MF0493Entities db = new MF0493Entities())
            {
                var data = from usuarios in db.Usuarios
                           where usuarios.username == "admin"
                           select usuarios;

                if (data.Count() == 0)
                {
                    Usuario u = new Usuario() 
                    { 
                        username = "admin",
                        activo = true,
                        email ="jucles@a2000.es",                        
                        passwdSinCifrar = "aaa111..."
                    };
                    db.Usuarios.Add(u);
                    db.SaveChanges();                    
                }
            }      

        }

    }
}