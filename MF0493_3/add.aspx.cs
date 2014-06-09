using MF0493_3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MF0493_3
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Nif_Valido(object source, ServerValidateEventArgs args)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKET";
            string nif = args.Value;
            try
            {
                int numero = Int32.Parse(nif.Substring(0, nif.Length - 1));
                string letra = nif.Substring(nif.Length - 1, 1);
                int pos = numero % 23;
                if (letras[pos].ToString() == letra.ToUpper()) args.IsValid = true;
                else args.IsValid = false;

            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
            //args.IsValid = true;
        }
        public void val_fecha(object source, ServerValidateEventArgs args)
        {
            int edad;
            string[] fecha = args.Value.Split('/');
            int dia = Int32.Parse(fecha[0]);
            int mes = Int32.Parse(fecha[1]);
            int anio = Int32.Parse(fecha[2]);

            DateTime fnac = new DateTime(anio, mes, dia);
            TimeSpan dif = new TimeSpan(DateTime.Now.Ticks - fnac.Ticks);

            edad = (int)(dif.Days / 356);
            args.IsValid = edad >= 18;
        }
        public void val_tel(object source, ServerValidateEventArgs args)
        {
            string tel = args.Value;
            args.IsValid = (tel[0] == '6' || tel[0] == '9');
        }
        public void val_email(object source, ServerValidateEventArgs args)
        {
            Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            args.IsValid = rgxEmail.IsMatch(args.Value);
        }
        protected void ValidarArchivo(object source, ServerValidateEventArgs args)
        {
            if (this.file_u.HasFile)
            {
                //no permitimos mas de 5MB de tamaño de archivo
                if (this.file_u.PostedFile.ContentLength >= (5000 * 1024))
                {
                    args.IsValid = false;
                    this.CustomValidator1.ErrorMessage = "El tamaño del archivo excede el maximo del tamaño";
                }
                else
                {
                    string ext = Path.GetExtension(this.file_u.PostedFile.FileName);
                    string[] validas = { ".jpg", ".png", ".gif" };
                    if (!validas.Contains(ext))
                    {
                        args.IsValid = false;
                        this.CustomValidator1.ErrorMessage = "El formato del archivo no es valido";
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Validate();
            if (this.IsValid)
            {
                Empresa emp = new Empresa();
                emp.activa = this.txtPyme.Checked;
                emp.nif = this.txtDni.Text;
                emp.nombre = this.txtNombre.Text;
                emp.poblacion = this.txtPoblacion.Text;
                emp.telefono = this.txtTlf.Text;
                emp.usr = ((Usuario)Session["usr"]).username;
                emp.ff = Convert.ToDateTime(this.txtFnac.Text);
                
                string ext = Path.GetExtension(this.file_u.PostedFile.FileName);
                this.file_u.PostedFile.SaveAs(Server.MapPath("~/logos/" + this.txtDni.Text + ext));
                emp.logo = "~/logos/" + this.txtDni.Text + ext;
                EmpresaManager.Nueva(emp);
                Response.Redirect("Default.aspx");
            }
        }//fin validar
    }
}