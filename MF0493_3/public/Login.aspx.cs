using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MF0493_3.Models;

namespace MF0493_3.PublicLogin
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void Entrar(object sender, AuthenticateEventArgs e)
        {
            //autentifica el usuario y el password con los del archivo de configuracion
            //valido = FormsAuthentication.Authenticate(this.Login1.UserName,this.Login1.Password);
            //autentifica el usuario y el password con los datos de la lista que tenemos en la variable de aplicacion

            MF0493Entities bd = new MF0493Entities();

            var usr = from usuarios in bd.Usuarios
                      where usuarios.username == this.Login1.UserName
                      select usuarios;


            if (usr.Count() == 0) {
                e.Authenticated = false;
                this.Login1.FailureText = "El usuario no existe en el sistema.";
            }
            else
            {
                Usuario u = usr.First();

                if (u != null && u.activo == true && u.validar(this.Login1.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                    e.Authenticated = true;
                    Session.Add("usr", u);
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    e.Authenticated = false;
                    if (u.activo == false)
                    {
                        this.Login1.FailureText = "El usuario esta bloqueado, conctacte con el administrador";
                    }
                    else
                    {
                        this.Login1.FailureText = "El nombre de usuario o contraseña son erroneos.";
                    }
                }
            }

        }
	}
}